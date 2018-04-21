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

	wprintf(L"CreateFile: %ls (checked %ls)\n", lpFileName, lpUnpatchedFileName);
	if (PathFileExists(lpUnpatchedFileName)) {
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
	MessageBox(NULL, L"CreateProcess!", L"", 0);
	wprintf(L"CreateProcess: %ls (%ls)\n", lpApplicationName, lpCommandLine);
	fflush(stdout);

	wchar_t ExtraClientFlags[100];
	if (!GetEnvironmentVariable(L"__BNSBOOST_CLIENTFLAGS", ExtraClientFlags, sizeof(ExtraClientFlags))) {
		exit(GetLastError());
	}

	DWORD dwSize = (lstrlen(lpCommandLine) + lstrlen(ExtraClientFlags) + 2) * sizeof(wchar_t);
	LPWSTR lpNewCommandLine = malloc(dwSize);
	StringCbCopy(lpNewCommandLine, dwSize, lpCommandLine);
	StringCbCat(lpNewCommandLine, dwSize, L" ");
	StringCbCat(lpNewCommandLine, dwSize, ExtraClientFlags);

	wchar_t commandLine[8191];
	memset(commandLine, 0, sizeof(commandLine));
	wcscpy(commandLine, L"C:\\dev\\BNSBoost\\bin\\Debug\\inject32.exe C:\\dev\\BNSBoost\\bin\\Debug\\agent_client32.dll ");
	wcscat(commandLine, lpCommandLine);
	wcscat(commandLine, L" ");
	wcscat(commandLine, ExtraClientFlags);

	wprintf(L"[%ls]\n", commandLine);

	wprintf(L"CreateProcess (new): %ls (%ls)\n", lpApplicationName, commandLine);
	wprintf(L"handles=%d, creation=%d, env=%ls\n", bInheritHandles, dwCreationFlags, lpEnvironment);
	BOOL ret = Real_CreateProcess(lpApplicationName,
		commandLine,
		lpProcessAttributes,
		lpThreadAttributes,
		bInheritHandles,
		dwCreationFlags,
		lpEnvironment,
		lpCurrentDirectory,
		lpStartupInfo,
		lpProcessInformation);

	free(lpNewCommandLine);
	exit(0xB00573D);
}

void InjectMain()
{
	printf("Entered injector!\n");

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

	printf("Injected!\n");
}

INT APIENTRY DllMain(HMODULE hDLL, DWORD Reason, LPVOID Reserved) {
	switch (Reason) {
	case DLL_PROCESS_ATTACH:
		DisableThreadLibraryCalls(hDLL);

		freopen("log.txt", "w", stdout);
		MessageBeep(-1);
		printf("Agent attached!\n");
		InjectMain();
		break;
	case DLL_PROCESS_DETACH:
		printf("Agent detached!\n");
		break;
	}

	fflush(stdout);
	return TRUE;
}
