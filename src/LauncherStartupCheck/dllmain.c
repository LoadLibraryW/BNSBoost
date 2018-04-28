#include "stdafx.h"
#include "proxydll.h"
#include "resourcehelper.h"

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
        void *pBlock;
        PLANGANDCODEPAGE plcp;
        size_t count;
        wchar_t *pProductName;
        wchar_t *pOriginalFilename;
        wchar_t szLastKnownLocation[MAX_PATH];
        wchar_t szIniPath[MAX_PATH];
        STARTUPINFOW si = { sizeof si };
        PROCESS_INFORMATION pi;

        switch ( ul_reason_for_call ) {
        case DLL_PROCESS_ATTACH:
                DisableThreadLibraryCalls(hModule);
                if ( !GetCurrentDirectoryW(_countof(szIniPath), szIniPath)
                        || wcscat_s(szIniPath, _countof(szIniPath), L"\\NCLauncher.ini") )
                        break;

                if ( !GetPrivateProfileStringW(L"BNSBoost_Settings",
                        L"LastKnownLocation",
                        NULL,
                        szLastKnownLocation,
                        _countof(szLastKnownLocation),
                        szIniPath) )
                        break;

                pBlock = rsrc_get_version_info(GetModuleHandleW(NULL));
                if ( !pBlock ) break;

                plcp = rsrc_query_var_file_info(pBlock, &count);
                if ( !plcp ) goto free_pBlock;

                pProductName = rsrc_query_string_file_info(pBlock, plcp[0], L"ProductName", NULL);
                if ( !pProductName ) goto free_pBlock;

                pOriginalFilename = rsrc_query_string_file_info(pBlock, plcp[0], L"OriginalFilename", NULL);
                if ( !pOriginalFilename ) goto free_pBlock;

                if ( !_wcsicmp(pProductName, L"NCLauncher Module")
                        || !_wcsicmp(pOriginalFilename, L"NCLauncher.exe")
                        || !GetEnvironmentVariableW(L"__BNSBOOST_BASEDIR", NULL, 0)
                        && GetLastError() == ERROR_ENVVAR_NOT_FOUND ) {

                        if ( GetPrivateProfileIntW(L"BNSBoost_Settings", L"AlwaysStartBNSBoost", 0, szIniPath)
                                || MessageBoxW(NULL, L"You are about to use NC Launcher without BNSBoost active, "
                                        L"which could undo any mods or other modifications you have applied. Are you sure you want to do this?\n\n"
                                        L"Press Yes to use NC Launcher without BNSBoost\n"
                                        L"Press No to start BNSBoost instead", L"BNSBoost", MB_ICONINFORMATION | MB_YESNO) == IDNO ) {
start_bnsboost:
                                if ( CreateProcessW(NULL, szLastKnownLocation, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi) ) {
                                        CloseHandle(pi.hThread);
                                        CloseHandle(pi.hProcess);
exit_process:
                                        ExitProcess(0);
                                } else {
                                        switch ( MessageBoxW(NULL, L"Failed to start BNSBoost!\n\n"
                                                L"Press Cancel to close\n"
                                                L"Press Try Again to attempt starting BNSBoost again\n"
                                                L"Press Continue to use NC Launcher without BNSBoost", L"BNSBoost", MB_ICONERROR | MB_CANCELTRYCONTINUE) ) {
                                        case IDTRYAGAIN:
                                                goto start_bnsboost;
                                        case IDCONTINUE:
                                                break;
                                        default:
                                                goto exit_process;
                                        }
                                }
                        }
                }
free_pBlock:
                free(pBlock);
                break;
        case DLL_PROCESS_DETACH:
                if ( !lpReserved )
                        real_dll_free();
                break;
        default:
                break;
        }
        return TRUE;
}
