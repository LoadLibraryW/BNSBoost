// cl /LD agent.c user32.lib kernel32.lib Shlwapi.lib /link /def:agent.def
#ifndef UNICODE
#define UNICODE
#endif

#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <windows.h>
#include <Psapi.h>
#include <Shlwapi.h>
#include <Strsafe.h>

#include <detours.h>

typedef HANDLE(WINAPI *CreateFile_t)(LPCWSTR, DWORD, DWORD, LPSECURITY_ATTRIBUTES, DWORD, DWORD, HANDLE);

static CreateFile_t Real_CreateFile;
static HANDLE WINAPI Hook_CreateFile(
	_In_     LPCWSTR               lpFileName,
	_In_     DWORD                 dwDesiredAccess,
	_In_     DWORD                 dwShareMode,
	_In_opt_ LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	_In_     DWORD                 dwCreationDisposition,
	_In_     DWORD                 dwFlagsAndAttributes,
	_In_opt_ HANDLE                hTemplateFile
) {
	DWORD dwSize = (lstrlen(lpFileName) + 1) * sizeof(wchar_t);
	LPWSTR lpBaseDir = malloc(dwSize);
	LPWSTR lpFileSpec = malloc(dwSize);
	LPWSTR lpRealFileName = malloc(dwSize);
	LPCWSTR lpUnpatchedDir = L"\\unpatched\\";

	StringCbCopy(lpRealFileName, dwSize, lpFileName);

	// Convert all / into \, since otherwise PathStripPath and PathRemoveFileSpec
	// treat e.g. "C:\\Program Files (x86)\\NCWest\\NCLauncher/Message.pak" as
	// lpBaseDir: C:\Program Files (x86)\NCWest
	// lpFileSpec: NCLauncher/Message.pak
	wchar_t *slash;
	while (lstrlen(slash = wcsstr(lpRealFileName, L"/")))
		*slash = L'\\';

	StringCbCopy(lpBaseDir, dwSize, lpRealFileName);
	StringCbCopy(lpFileSpec, dwSize, lpRealFileName);

	PathStripPath(lpFileSpec);
	PathRemoveFileSpec(lpBaseDir);

	dwSize = (lstrlen(lpBaseDir) + lstrlen(lpFileSpec) + lstrlen(lpUnpatchedDir) + 1) * sizeof(wchar_t);

	LPWSTR lpUnpatchedFileName = malloc(dwSize);
	StringCbCopy(lpUnpatchedFileName, dwSize, lpBaseDir);
	StringCbCat(lpUnpatchedFileName, dwSize, lpUnpatchedDir);
	StringCbCat(lpUnpatchedFileName, dwSize, lpFileSpec);

	//OutputDebugString(L"CreateFile:");
	//OutputDebugString(lpFileName);
	//OutputDebugString(lpUnpatchedFileName);

	wprintf(L"CreateFile: %ls (checked %ls)\n", lpFileName, lpUnpatchedFileName);
	if (PathFileExists(lpUnpatchedFileName)) {
		OutputDebugString(L"Patched!");
		OutputDebugString(lpFileName);
		OutputDebugString(lpUnpatchedFileName);
		wprintf(L"\t Patched %ls to %ls\n", lpFileName, lpUnpatchedFileName);
		fflush(stdout);
		lpFileName = lpUnpatchedFileName;
	}

	HANDLE ret = Real_CreateFile(lpFileName,
		dwDesiredAccess,
		dwShareMode,
		lpSecurityAttributes,
		dwCreationDisposition,
		dwFlagsAndAttributes,
		hTemplateFile);

	free(lpBaseDir);
	free(lpFileSpec);
	free(lpUnpatchedFileName);

	return ret;
}

typedef HANDLE(WINAPI *CreateProcess_t) (LPCWSTR, LPWSTR, LPSECURITY_ATTRIBUTES, LPSECURITY_ATTRIBUTES,
	BOOL, DWORD, LPVOID, LPCWSTR, LPSTARTUPINFO, LPPROCESS_INFORMATION);

static CreateProcess_t Real_CreateProcess;
BOOL WINAPI Hook_CreateProcess(
	_In_opt_    LPCWSTR               lpApplicationName,
	_Inout_opt_ LPWSTR                lpCommandLine,
	_In_opt_    LPSECURITY_ATTRIBUTES lpProcessAttributes,
	_In_opt_    LPSECURITY_ATTRIBUTES lpThreadAttributes,
	_In_        BOOL                  bInheritHandles,
	_In_        DWORD                 dwCreationFlags,
	_In_opt_    LPVOID                lpEnvironment,
	_In_opt_    LPCWSTR               lpCurrentDirectory,
	_In_        LPSTARTUPINFO         lpStartupInfo,
	_Out_       LPPROCESS_INFORMATION lpProcessInformation
) {
	wchar_t envBuf[100];
	if (!GetEnvironmentVariable(L"__BNSBOOST_CLIENTFLAGS", envBuf, sizeof(envBuf))) {
		exit(GetLastError());
	}

	DWORD dwSize = (lstrlen(lpCommandLine) + lstrlen(envBuf) + 2) * sizeof(wchar_t);
	LPWSTR lpNewCommandLine = malloc(dwSize);
	wcscpy(lpNewCommandLine, lpCommandLine);
	wcscat(lpNewCommandLine, L" ");
	wcscat(lpNewCommandLine, envBuf);

	BOOL bX3Disabled = GetEnvironmentVariable(L"__BNSBOOST_NOX3", envBuf, sizeof(envBuf));

	Real_CreateProcess(lpApplicationName,
		lpNewCommandLine,
		lpProcessAttributes,
		lpThreadAttributes,
		bInheritHandles,
		dwCreationFlags | (bX3Disabled ? CREATE_SUSPENDED : 0),
		lpEnvironment,
		lpCurrentDirectory,
		lpStartupInfo,
		lpProcessInformation);

	if (bX3Disabled) {
		BOOL bIs64 = GetEnvironmentVariable(L"__BNSBOOST_IS64", envBuf, sizeof(envBuf));

		wchar_t agentPath[MAX_PATH];
		wchar_t injectPath[MAX_PATH];

		GetEnvironmentVariable(L"__BNSBOOST_BASEDIR", agentPath, sizeof(agentPath));
		GetEnvironmentVariable(L"__BNSBOOST_BASEDIR", injectPath, sizeof(injectPath));

		wcscat(agentPath, L"\\");
		wcscat(injectPath, L"\\");

		if (bIs64) {
			wcscat(agentPath, L"agent_client64.dll");
			wcscat(injectPath, L"inject64.exe");
		}
		else {
			wcscat(agentPath, L"agent_client32.dll");
			wcscat(injectPath, L"inject32.exe");
		}

		wchar_t injector[8191];
		wsprintf(injector, L"\"%ls\" \"%ls\" %d", injectPath, agentPath, lpProcessInformation->dwProcessId);

		STARTUPINFO si;
		PROCESS_INFORMATION pi;

		ZeroMemory(&si, sizeof(si));
		si.cb = sizeof(si);
		ZeroMemory(&pi, sizeof(pi));

		if (!Real_CreateProcess(NULL, injector, NULL, NULL, FALSE, CREATE_NO_WINDOW, NULL, NULL, &si, &pi)) {
			MessageBox(NULL, L"Couldn't create injector process :-(", L"", 0);
			exit(GetLastError());
		}

		WaitForSingleObject(pi.hProcess, INFINITE);
		ResumeThread(lpProcessInformation->hThread);
	}

	free(lpNewCommandLine);
	exit(0xB00573D);
}

void InjectMain()
{
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());

	Real_CreateFile = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateFileW");
	if (DetourAttach(&Real_CreateFile, Hook_CreateFile)) {
		MessageBox(NULL, L"Failed CreateFile hook", L"", 0);
	}

	Real_CreateProcess = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateProcessW");
	if (DetourAttach(&Real_CreateProcess, Hook_CreateProcess)) {
		MessageBox(NULL, L"Failed CreateProcess hook", L"", 0);
	}

	int error = DetourTransactionCommit();
	if (error != NO_ERROR)
	{
		MessageBox(NULL, L"Hooking error!", L"", 0);
		exit(error);
	}
}

INT APIENTRY DllMain(HMODULE hDLL, DWORD Reason, LPVOID Reserved) {
	switch (Reason) {
	case DLL_PROCESS_ATTACH:
		DisableThreadLibraryCalls(hDLL);
		MessageBeep(-1);
		InjectMain();
		break;
	}

	fflush(stdout);
	return TRUE;
}
