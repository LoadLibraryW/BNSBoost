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

	fwprintf(stderr, "Agent: %ls\n", lpAgentPath);

	if (!DetourCreateProcessWithDll(NULL,
		lpImageCommandLine,
		NULL,
		NULL,
		TRUE,
		0,
		NULL,
		NULL,
		&si,
		&pi,
		"Agent.dll",
		NULL))
	{
		fprintf(stderr, "DetourCreateProcessWithDll failed (%d).\n", GetLastError());
		return GetLastError();
	}

	fprintf(stderr, "Launched PID!: %d\n", pi.dwProcessId);

	WaitForSingleObject(pi.hProcess, INFINITE);
	DWORD exitcode;
	GetExitCodeProcess(pi.hProcess, &exitcode);
	fprintf(stderr, "Exited with: %04X\n", exitcode);
	CloseHandle(pi.hProcess);
	CloseHandle(pi.hThread);

	return exitcode;
}

int wmain(int argc, const wchar_t **argv)
{
	if (argc != 3) {
		fprintf(stderr, "Usage:\n\tinject.exe [agent dll] [executable and arguments]\n");
		exit(1);
	}

	return LaunchImageWithAgent(argv[2], argv[1]);
}