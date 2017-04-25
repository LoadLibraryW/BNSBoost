// cl main.cpp Advapi32.lib /Feinjector.exe
#include <windows.h>
#include <stdio.h>
#include <tchar.h>
#include "Strsafe.h"

BYTE asmX86[] = {
	/* 0000 */ 0x55,             // push ebp
	/* 0001 */ 0x8B, 0xEC,       // mov  ebp, esp
	/* 0003 */ 0x68, 0, 0, 0, 0, // push <library name (UTF-16)>
	/* 0008 */ 0xB9, 0, 0, 0, 0, // mov  ecx, LoadLibraryW
	/* 000D */ 0xFF, 0xD1,       // call ecx
	/* 000F */ 0x68, 0, 0, 0, 0, // push <function name (ASCII)>
	/* 0014 */ 0x50,             // push eax
	/* 0015 */ 0xB9, 0, 0, 0, 0, // mov  ecx, GetProcAddress
	/* 001A */ 0xFF, 0xD1,       // call ecx
	/* 001C */ 0xFF, 0xD0,       // call eax
	/* 001E */ 0x33, 0xC0,       // xor  eax, eax
	/* 0020 */ 0x5D,             // pop  ebp
	/* 0021 */ 0xC2, 0x04, 0     // ret  4
};

inline void writeDword(BYTE *buf, DWORD dword)
{
    buf[0] = dword & 0xFF;
    buf[1] = (dword >> 8) & 0xFF;
    buf[2] = (dword >> 16) & 0xFF;
    buf[3] = (dword >> 24) & 0xFF;
}

BOOL inject(HANDLE hProcess, LPCWSTR szDllPath, LPCSTR szFunctionName)
{
    // Mostly from the DMOJ's Windows sandbox; https://github.com/DMOJ/judge
    HMODULE hKernel32 = GetModuleHandleW(L"kernel32.dll");
    printf("LoadLibraryW @ %04X\n", (UINT32) (INT_PTR) GetProcAddress(hKernel32, "LoadLibraryW"));
    printf("GetProcAddress @ %04X\n", (UINT32) (INT_PTR) GetProcAddress(hKernel32, "GetProcAddress"));
    writeDword(asmX86 + 9, (UINT32) (INT_PTR) GetProcAddress(hKernel32, "LoadLibraryW"));
    writeDword(asmX86 + 22, (UINT32) (INT_PTR) GetProcAddress(hKernel32, "GetProcAddress"));

	HANDLE hInject;
	BYTE asmCode[sizeof asmX86];
	LPVOID lpDllPath, lpFunctionName, lpCode;
	DWORD cbDllPath, cbFunctionName = lstrlenA(szFunctionName) + 1;

	cbDllPath = (lstrlenW(szDllPath) + 1) * sizeof(WCHAR);

	lpDllPath = VirtualAllocEx(hProcess, NULL, cbDllPath, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
	if (!lpDllPath)
    {
        printf("Could not allocate DLL path memory: %d\n", GetLastError());
        return FALSE;
    }

	if (!WriteProcessMemory(hProcess, lpDllPath, szDllPath, cbDllPath, NULL))
    {
        printf("Could not write DLL path memory: %d\n", GetLastError());
        return FALSE;
    }

	lpFunctionName = VirtualAllocEx(hProcess, NULL, cbFunctionName, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
	if (!lpFunctionName)
    {
        printf("Could not allocate function name memory: %d\n", GetLastError());
        return FALSE;
    }

	if (!WriteProcessMemory(hProcess, lpFunctionName, szFunctionName, cbFunctionName, NULL))
    {
        printf("Could not write function name memory: %d\n", GetLastError());
        return FALSE;
    }

    DWORD dwDllPath, dwFunctionName;

    memcpy(asmCode, asmX86, sizeof asmX86);
    dwDllPath = (DWORD) (INT_PTR) lpDllPath;
    dwFunctionName = (DWORD) (INT_PTR) lpFunctionName;

    writeDword(asmCode + 4, dwDllPath);
    writeDword(asmCode + 16, dwFunctionName);

	lpCode = VirtualAllocEx(hProcess, NULL, sizeof asmCode, MEM_RESERVE | MEM_COMMIT, PAGE_EXECUTE_READWRITE);
	if (!lpCode)
    {
        printf("Could not allocate injection memory: %d\n", GetLastError());
        return FALSE;
    }

	if (!WriteProcessMemory(hProcess, lpCode, asmCode, sizeof asmCode, NULL))
    {
        printf("Could not write injection memory: %d\n", GetLastError());
        return FALSE;
    }


	if (!(hInject = CreateRemoteThread(hProcess, NULL, 0, (LPTHREAD_START_ROUTINE) lpCode, NULL, 0, NULL)))
    {
        printf("Could not create remote thread: %d\n", GetLastError());
        return FALSE;
    }


	WaitForSingleObject(hInject, INFINITE);

	VirtualFreeEx(hProcess, lpDllPath, cbDllPath, MEM_RELEASE);
	VirtualFreeEx(hProcess, lpFunctionName, cbFunctionName, MEM_RELEASE);
	VirtualFreeEx(hProcess, lpCode, sizeof asmCode, MEM_RELEASE);
	return TRUE;
}

int main(int argc, char *argv[])
{
    STARTUPINFOW si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    wchar_t launcherBaseDir[255];
    DWORD BufferSize = sizeof launcherBaseDir;
	RegGetValueW(HKEY_LOCAL_MACHINE, L"SOFTWARE\\NCWest\\NCLauncher\\", L"BaseDir", RRF_RT_ANY, NULL, (PVOID) &launcherBaseDir, &BufferSize);
	wprintf(L"Using launcher dir: %ls\n", &launcherBaseDir[0]);

    LPWSTR launcherFlags = L"\\ncLauncherR.exe\" /LauncherID:\"NCWest\" /CompanyID:\"12\" /GameID:\"BnS\" /LUpdateAddr:\"updater.nclauncher.ncsoft.com\"";
    DWORD dwSize = (lstrlenW(launcherBaseDir) + lstrlenW(launcherFlags) + 2) * sizeof(wchar_t);
    LPWSTR ncLauncherCommandLine = (LPWSTR) malloc(dwSize);
    StringCbCopyW(ncLauncherCommandLine, dwSize, L"\"");
    StringCbCatW(ncLauncherCommandLine, dwSize, launcherBaseDir);
    StringCbCatW(ncLauncherCommandLine, dwSize, launcherFlags);

    if(!CreateProcessW(NULL,
                       ncLauncherCommandLine,
                       NULL,
                       NULL,
                       TRUE,
                       CREATE_SUSPENDED,
                       NULL,
                       NULL,
                       &si,
                       &pi))
    {
        printf("CreateProcess failed (%d).\n", GetLastError());
        return 0;
    }

    free(ncLauncherCommandLine);

    printf("Launcher PID: %d\n", pi.dwProcessId);

    dwSize = 255 * sizeof (wchar_t);
    LPWSTR agentPath = (LPWSTR) malloc(dwSize);
    DWORD cwdSz = GetCurrentDirectoryW(lstrlenW(agentPath), agentPath);
    StringCbCatW(agentPath, dwSize, L"\\agent.dll");

    wprintf(L"Using agent: %ls\n", agentPath);

    inject(pi.hProcess, agentPath, "InjectMain");
    free(agentPath);

    ResumeThread(pi.hThread);

    WaitForSingleObject(pi.hProcess, INFINITE);
    DWORD exitcode;
    GetExitCodeProcess(pi.hProcess, &exitcode);
    printf("Exited with: %04X\n", exitcode);
    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);
}
