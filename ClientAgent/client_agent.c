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
	HANDLE ret = Real_CreateFile(lpFileName,
		dwDesiredAccess,
		dwShareMode ? dwShareMode : FILE_SHARE_READ,
		lpSecurityAttributes,
		dwCreationDisposition,
		dwFlagsAndAttributes,
		hTemplateFile);

	return ret;
}

typedef HANDLE(WINAPI *CreateMutex_t) (LPSECURITY_ATTRIBUTES, BOOL, LPCTSTR);

static CreateMutex_t Real_CreateMutex;
HANDLE WINAPI Hook_CreateMutex(
	_In_opt_ LPSECURITY_ATTRIBUTES lpMutexAttributes,
	_In_     BOOL                  bInitialOwner,
	_In_opt_ LPCTSTR               lpName
) {
	//MessageBox(NULL, lpName, L"CreateMutex!", 0);
	return Real_CreateMutex(lpMutexAttributes, bInitialOwner, lpName);
}

void InjectMain()
{
	printf("Entered injector!\n");

	MessageBox(NULL, L"Injecting!!", L"", 0);
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());

	Real_CreateFile = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateFileW");
	if (DetourAttach(&Real_CreateFile, Hook_CreateFile)) {
		MessageBox(NULL, L"Failed CreateFile hook", L"", 0);
	}

	Real_CreateMutex = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "CreateMutexW");
	if (DetourAttach(&Real_CreateMutex, Hook_CreateMutex)) {
		MessageBox(NULL, L"Failed CreateMutex hook", L"", 0);
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
		//DisableThreadLibraryCalls(hDLL);

		MessageBox(NULL, L"We're in!!", L"", 0);
		freopen("C:\\dev\\BNSBoost\\log-client.txt", "w", stdout);
		MessageBeep(-1);
		printf("Agent attached!\n");
		//InjectMain();
		break;
	case DLL_PROCESS_DETACH:
		printf("Agent detached!\n");
		break;
	}

	fflush(stdout);
	return TRUE;
}
