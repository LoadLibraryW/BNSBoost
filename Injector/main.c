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

#include <detours.h>

int LaunchImageWithAgent(LPWSTR lpImageCommandLine, LPWSTR lpAgentPath) {
	STARTUPINFO si;
	PROCESS_INFORMATION pi;

	ZeroMemory(&si, sizeof(si));
	si.cb = sizeof(si);
	ZeroMemory(&pi, sizeof(pi));

	wprintf(L"Agent: %ls\n", lpAgentPath);

	char agentPath[MAX_PATH];
	wcstombs(agentPath, lpAgentPath, sizeof(agentPath));

	if (!DetourCreateProcessWithDll(NULL,
		lpImageCommandLine,
		NULL,
		NULL,
		FALSE,
		67108864,
		NULL,
		NULL,
		&si,
		&pi,
		agentPath,
		NULL))
	{
		printf("DetourCreateProcessWithDll failed (%d).\n", GetLastError());
		return GetLastError();
	}

	printf("Launched PID!: %d\n", pi.dwProcessId);

	WaitForSingleObject(pi.hProcess, INFINITE);
	DWORD exitcode;
	GetExitCodeProcess(pi.hProcess, &exitcode);
	printf("Exited with: %04X\n", exitcode);
	CloseHandle(pi.hProcess);
	CloseHandle(pi.hThread);

	getch();

	return exitcode;
}

int wmain(int argc, const wchar_t **argv)
{
	if (argc < 3) {
		fprintf(stderr, "Usage!s:\n\tinject.exe [agent dll] [executable and arguments]\n");
		exit(1);
	}

	wchar_t *line = GetCommandLine();
	wprintf(L">>> %ls\n", line);

	int spaces = 0;
	BOOL quoteOpen = FALSE;
	int i;
	for (i = 0; i < wcslen(line); i++) {
		if (!quoteOpen && line[i] != L' ' && i - 1 > 0 && line[i - 1] == L' ') {
			spaces++;

			if (spaces == 2) break;
		}

		quoteOpen ^= line[i] == L'"' && (i - 1 == 0 || line[i - 1] != L'\\');
	}

	wprintf(L"command line: [%ls]\n", line + i);
	return LaunchImageWithAgent(line + i, argv[1]);
}