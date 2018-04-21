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

typedef HANDLE(WINAPI *CreateMutex_t) (LPSECURITY_ATTRIBUTES, BOOL, LPCTSTR);

static CreateMutex_t Real_CreateMutex;
HANDLE WINAPI Hook_CreateMutex(
	_In_opt_ LPSECURITY_ATTRIBUTES lpMutexAttributes,
	_In_     BOOL                  bInitialOwner,
	_In_opt_ LPCTSTR               lpName
) {
	// The game grabs a mutex named "BnSGameClient" so that a new instance can stop when another is already running
	// To prevent this, if the name is "BnSGameClient", just make it a regular (unnamed) mutex instead
	return Real_CreateMutex(lpMutexAttributes, bInitialOwner, (lpName && !wcscmp(L"BnSGameClient", lpName)) ? NULL : lpName);
}

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

	// The game grabs exclusive access to xml[bit].dat and config[bit].dat, which prevents a second client
	// from successfully starting, so force it to share read on all files at least
	return Real_CreateFile(lpFileName,
		dwDesiredAccess,
		dwShareMode ? dwShareMode : FILE_SHARE_READ,
		lpSecurityAttributes,
		dwCreationDisposition,
		dwFlagsAndAttributes,
		hTemplateFile);
}

typedef HANDLE(WINAPI *LoadLibrary_t)(LPCWSTR);

static LoadLibrary_t Real_LoadLibrary;
static HMODULE WINAPI Hook_LoadLibrary(
	_In_ LPCWSTR lpFileName
) {
	OutputDebugStringW(L"LoadLibrary:");
	OutputDebugStringW(lpFileName);

	wchar_t *patch = NULL;

	if (wcsstr(lpFileName, L"xcorona_x64.xem") != NULL) {
		patch = L"\\xcorona_x64.xem";
	}
	else if (wcsstr(lpFileName, L"x3.xem") != NULL) {
		patch = L"\\x3.xem";
	}

	if (patch) {
		OutputDebugStringW(L"Hooking!");

		wchar_t patchPath[MAX_PATH];
		GetEnvironmentVariable(L"__BNSBOOST_BASEDIR", patchPath, sizeof(patchPath));
		wcscat(patchPath, patch);

		OutputDebugStringW(patchPath);

		lpFileName = patchPath;
	}

	return Real_LoadLibrary(lpFileName);
}

void InjectMain()
{
	wchar_t envBuf[100];

	BOOL bMulticlientEnabled = GetEnvironmentVariable(L"__BNSBOOST_MULTICLIENT", envBuf, sizeof(envBuf));

	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());

	if (bMulticlientEnabled) {
		OutputDebugStringW(L"Patching multiclient support");

		Real_CreateFile = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateFileW");
		if (DetourAttach(&Real_CreateFile, Hook_CreateFile)) {
			MessageBox(NULL, L"Failed CreateFile hook", L"", 0);
		}

		Real_CreateMutex = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateMutexW");
		if (DetourAttach(&Real_CreateMutex, Hook_CreateMutex)) {
			MessageBox(NULL, L"Failed CreateMutex hook", L"", 0);
		}
	}

	Real_LoadLibrary = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "LoadLibraryW");
	if (DetourAttach(&Real_LoadLibrary, Hook_LoadLibrary)) {
		MessageBox(NULL, L"Failed LoadLibrary hook", L"", 0);
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

	return TRUE;
}
