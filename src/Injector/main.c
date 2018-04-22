// cl main.c Advapi32.lib Shlwapi.lib /FeBNSBoost.exe
#ifndef UNICODE
#define UNICODE
#endif

#define _CRT_SECURE_NO_WARNINGS

#include <windows.h>
#include <stdio.h>
#include <tchar.h>
#include <Strsafe.h>
#include <Shlwapi.h>

int InjectProcessWithAgent(int pid, LPWSTR lpAgentPath) {
	printf("Injecting PID: %d\n", pid);
	wprintf(L"Agent: %ls\n", lpAgentPath);

	DWORD dwSize = (wcslen(lpAgentPath) + 1) * sizeof(wchar_t);

	HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);
	if (!hProcess) {
		fprintf(stderr, "Could not open process: %d\n", GetLastError());
		return -1;
	}

	LPVOID lpAgentMem = VirtualAllocEx(hProcess, NULL, dwSize, MEM_RESERVE | MEM_COMMIT, PAGE_EXECUTE_READWRITE);
	if (!lpAgentMem) {
		fprintf(stderr, "Could not allocate memory for agent path: %d\n", GetLastError());
		return -1;
	}

	if (!WriteProcessMemory(hProcess, lpAgentMem, lpAgentPath, dwSize, NULL)) {
		fprintf(stderr, "Could write agent path: %d\n", GetLastError());
		return -1;
	}

	LPVOID lpLoadLibraryW = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "LoadLibraryW");

	if (!lpLoadLibraryW) {
		fprintf(stderr, "Could get LoadLibraryW address: %d\n", GetLastError());
		return -1;
	}

	HANDLE hThread = CreateRemoteThread(hProcess, NULL, NULL, (LPTHREAD_START_ROUTINE)lpLoadLibraryW, lpAgentMem, NULL, NULL);

	if (!hThread) {
		fprintf(stderr, "Could not create remote thread: %d\n", GetLastError());
		return -1;
	}

	WaitForSingleObject(hThread, INFINITE);
	CloseHandle(hThread);

	fprintf(stderr, "Done!\n");

	CloseHandle(hProcess);

	// free mem

	return 0;
}

int wmain(int argc, const wchar_t **argv)
{
	if (argc != 3) {
		fprintf(stderr, "Usage!s:\n\tinject.exe [agent dll] [process id]\n");
		exit(1);
	}

	int pid = wcstol(argv[2], NULL, 10);
	int ret = InjectProcessWithAgent(pid, argv[1]);
	fflush(stderr);
	return ret;
}