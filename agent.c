// cl /LD agent.c user32.lib kernel32.lib Shlwapi.lib /link /def:agent.def
#include <stdio.h>
#include <windows.h>
#include <Psapi.h>
#include "Shlwapi.h"
#include "Strsafe.h"

void Patch(const char *function, void *hook, HANDLE module)
{
    // https://guidedhacking.com/showthread.php?4244-IAT-hook-Import-Address-Table-Hooking-Explained
    PIMAGE_DOS_HEADER pImgDosHeaders = (PIMAGE_DOS_HEADER) module;
    PIMAGE_NT_HEADERS pImgNTHeaders = (PIMAGE_NT_HEADERS)((LPBYTE) pImgDosHeaders + pImgDosHeaders->e_lfanew);
    PIMAGE_IMPORT_DESCRIPTOR pImgImportDesc = (PIMAGE_IMPORT_DESCRIPTOR)((LPBYTE)pImgDosHeaders + pImgNTHeaders->OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_IMPORT].VirtualAddress);
    
    int sz = (int)((LPBYTE)pImgDosHeaders + pImgNTHeaders->OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_IMPORT].Size);
    for (IMAGE_IMPORT_DESCRIPTOR* iid = pImgImportDesc; iid->Name != NULL; iid++)
    {
        for (int funcIdx = 0; *(funcIdx + (LPVOID*)(iid->FirstThunk + (SIZE_T)module)) != NULL; funcIdx++)
        {
            char* modFuncName = (char*)(*(funcIdx + (SIZE_T*)(iid->OriginalFirstThunk + (SIZE_T)module)) + (SIZE_T)module + 2);
            fflush(stdout);
            
            if (!_stricmp(function, modFuncName))
            {
                LPVOID *funcptr = (funcIdx + (LPVOID*)(iid->FirstThunk + (SIZE_T)module));
                
                DWORD oldrights;
                DWORD newrights = PAGE_READWRITE;
                
                VirtualProtect(funcptr, sizeof(LPVOID), newrights, &oldrights);
                
                *funcptr = hook;
                
                VirtualProtect(funcptr, sizeof(LPVOID), oldrights, &newrights);
                return;
            }
        }
    }
    return;
}

HANDLE WINAPI MyCreateFile(
  _In_     LPCWSTR               lpFileName,
  _In_     DWORD                 dwDesiredAccess,
  _In_     DWORD                 dwShareMode,
  _In_opt_ LPSECURITY_ATTRIBUTES lpSecurityAttributes,
  _In_     DWORD                 dwCreationDisposition,
  _In_     DWORD                 dwFlagsAndAttributes,
  _In_opt_ HANDLE                hTemplateFile
) {
    DWORD dwSize = (lstrlenW(lpFileName) + 1) * sizeof(wchar_t);
    LPCWSTR filename = malloc(dwSize);
    LPCWSTR filepath = malloc(dwSize);
    LPCWSTR unpatched = L"/unpatched/";
    
    StringCbCopyW(filename, dwSize, lpFileName);
    StringCbCopyW(filepath, dwSize, lpFileName);
    
    PathStripPathW(filename);
    PathRemoveFileSpecW(filepath);
    
    dwSize = (lstrlenW(filename) + lstrlenW(filepath) + lstrlenW(unpatched) + 1) * sizeof(wchar_t);
    LPCWSTR patchedFile = (LPCWSTR) malloc(dwSize);
    StringCbCopyW(patchedFile, dwSize, filepath);
    StringCbCatW(patchedFile, dwSize, unpatched);
    StringCbCatW(patchedFile, dwSize, filename);
    
    wprintf(L"CreateFile: %ls\n", lpFileName);
    
    if (PathFileExistsW(patchedFile)) {
        wprintf(L"\t Patched to ");
        wprintf(L"%ls\n", patchedFile);
        lpFileName = patchedFile;
    }
    
    HANDLE ret = CreateFileW(lpFileName,
                             dwDesiredAccess,
                             dwShareMode,
                             lpSecurityAttributes,
                             dwCreationDisposition,
                             dwFlagsAndAttributes,
                             hTemplateFile);
                       
    free(filename);
    free(filepath);
    free(patchedFile);

    fflush(stdout);

    return ret;
}

BOOL WINAPI MyCreateProcess(
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
    wprintf(L"CreateProcess: %ls (%ls)\n", lpApplicationName, lpCommandLine); 
    fflush(stdout);
    
    LPWSTR flags = L" -NOTEXTURESTREAMING -UNATTENDED -USEALLAVAILABLECORES";
    DWORD dwSize = (lstrlenW(lpCommandLine) + lstrlenW(flags) + 1) * sizeof(wchar_t);
    LPWSTR newCommandLine = malloc(dwSize);
    StringCbCopyW(newCommandLine, dwSize, lpCommandLine);
    StringCbCatW(newCommandLine, dwSize, flags);
    
    wprintf(L"CreateProcess (new): %ls (%ls)\n", lpApplicationName, newCommandLine); 

    BOOL ret = CreateProcessW(lpApplicationName,
                              newCommandLine,
                              lpProcessAttributes,
                              lpThreadAttributes,
                              bInheritHandles,
                              dwCreationFlags,
                              lpEnvironment,
                              lpCurrentDirectory,
                              lpStartupInfo,
                              lpProcessInformation);

    free(newCommandLine);
    return ret;
}

HMODULE WINAPI MyLoadLibrary(
  _In_ LPCWSTR lpFileName
) {    
    wprintf(L"LoadLibrary: %ls\n", lpFileName);
    fflush(stdout);
    HMODULE mod = LoadLibraryW(lpFileName);
    Patch("CreateFileW", &MyCreateFile, mod);
    return mod;
}

__declspec(dllexport) VOID WINAPI InjectMain()
{
	freopen("log.txt", "w", stdout);
	printf("Entered injector!\n");
    MessageBeep(-1);
    Patch("CreateFileW", &MyCreateFile, GetModuleHandle(NULL));
    Patch("LoadLibraryW", &MyLoadLibrary, GetModuleHandle(NULL));
    Patch("CreateProcessW", &MyCreateProcess, GetModuleHandle(NULL));
    printf("Injected!\n");
}

INT APIENTRY DllMain(HMODULE hDLL, DWORD Reason, LPVOID Reserved) {
    switch(Reason) {
        case DLL_PROCESS_ATTACH:
            printf("Agent attached!\n");
            break;
        case DLL_PROCESS_DETACH:
            printf("Agent detached!\n");
            break;
    }

	return TRUE;
}
