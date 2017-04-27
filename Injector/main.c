// cl main.c Advapi32.lib Shlwapi.lib /FeBNSBoost.exe
#define UNICODE

#include <windows.h>
#include <stdio.h>
#include <tchar.h>
#include <Strsafe.h>
#include <Shlwapi.h>

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
	/*      */ 0x68, 0, 0, 0, 0, // push <extra client flags (UTF-16),
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

BOOL Inject(HANDLE hProcess, LPCWSTR szDllPath, LPCSTR szFunctionName, LPCWSTR szExtraClientFlags)
{
    // Mostly from the DMOJ's Windows sandbox; https://github.com/DMOJ/judge
    HMODULE hKernel32 = GetModuleHandle(L"kernel32.dll");
    printf("LoadLibraryW @ %04X\n", (UINT32) (INT_PTR) GetProcAddress(hKernel32, "LoadLibraryW"));
    printf("GetProcAddress @ %04X\n", (UINT32) (INT_PTR) GetProcAddress(hKernel32, "GetProcAddress"));
    writeDword(asmX86 + 9, (UINT32) (INT_PTR) GetProcAddress(hKernel32, "LoadLibraryW"));
    writeDword(asmX86 + 22, (UINT32) (INT_PTR) GetProcAddress(hKernel32, "GetProcAddress"));

    HANDLE hInject;
    BYTE asmCode[sizeof asmX86];
    LPVOID lpDllPath, lpFunctionName, lpExtraClientFlags, lpCode;
    DWORD cbDllPath, cbExtraClientFlags, cbFunctionName = lstrlenA(szFunctionName) + 1;

    cbDllPath = (lstrlen(szDllPath) + 1) * sizeof(WCHAR);
	cbExtraClientFlags = (lstrlen(szExtraClientFlags) + 1) * sizeof(WCHAR);

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

	lpExtraClientFlags = VirtualAllocEx(hProcess, NULL, cbExtraClientFlags, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
	if (!lpExtraClientFlags)
	{
		printf("Could not allocate extra flag memory: %d\n", GetLastError());
		return FALSE;
	}

	if (!WriteProcessMemory(hProcess, lpExtraClientFlags, szExtraClientFlags, cbExtraClientFlags, NULL))
	{
		printf("Could not write extra flag memory: %d\n", GetLastError());
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

    DWORD dwDllPath, dwFunctionName, dwExtraClientFlags;

    memcpy(asmCode, asmX86, sizeof asmX86);
    dwDllPath = (DWORD) (INT_PTR) lpDllPath;
    dwFunctionName = (DWORD) (INT_PTR) lpFunctionName;
	dwExtraClientFlags = (DWORD)(INT_PTR) lpExtraClientFlags;

    writeDword(asmCode + 4, dwDllPath);
    writeDword(asmCode + 16, dwFunctionName);
	writeDword(asmCode + 29, dwExtraClientFlags);

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

__declspec(dllexport) INT WINAPI Launch(LPWSTR lpLauncherBaseDir, LPWSTR lpExtraClientFlags)
{
    STARTUPINFO si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

	wprintf(L"Using launcher dir: %ls\n", lpLauncherBaseDir);

    LPWSTR lpLauncherFlags = L"\" /LauncherID:\"NCWest\" /CompanyID:\"12\" /GameID:\"BnS\" /LUpdateAddr:\"updater.nclauncher.ncsoft.com\"";
    DWORD dwSize = (lstrlen(lpLauncherBaseDir) + lstrlen(lpLauncherFlags) + 2) * sizeof(wchar_t);
    LPWSTR lpNCLauncherCommandLine = malloc(dwSize);
    ZeroMemory(lpNCLauncherCommandLine, dwSize);
    StringCbCopy(lpNCLauncherCommandLine, dwSize, L"\"");
    StringCbCat(lpNCLauncherCommandLine, dwSize, lpLauncherBaseDir);
    StringCbCat(lpNCLauncherCommandLine, dwSize, lpLauncherFlags);

    if(!CreateProcess(NULL,
                      lpNCLauncherCommandLine,
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
        return GetLastError();
    }

    free(lpNCLauncherCommandLine);

    printf("Launcher PID: %d\n", pi.dwProcessId);

    dwSize = MAX_PATH * sizeof (wchar_t);
    LPWSTR lpAgentPath = malloc(dwSize);
    ZeroMemory(lpAgentPath, dwSize);
    GetModuleFileName(GetModuleHandle(NULL), lpAgentPath, dwSize);
    PathRemoveFileSpec(lpAgentPath);
    StringCbCat(lpAgentPath, dwSize, L"\\agent.dll");

    wprintf(L"Using agent: %ls\n", lpAgentPath);

    Inject(pi.hProcess, lpAgentPath, "InjectMain", lpExtraClientFlags);
    free(lpAgentPath);

    ResumeThread(pi.hThread);

    WaitForSingleObject(pi.hProcess, INFINITE);
    DWORD exitcode;
    GetExitCodeProcess(pi.hProcess, &exitcode);
    printf("Exited with: %04X\n", exitcode);
    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);

	// Our own exit
	if (exitcode == 0xB00573D)
		exitcode = 0;
    return exitcode;
}
