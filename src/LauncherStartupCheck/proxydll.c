#include "stdafx.h"
#include "proxydll.h"

static HMODULE hmod;
static LPCSTR export_names[] = {
        EXPORT_NAMES
#if defined(_X86_) && defined(EXPORT_NAMES32)
        , EXPORT_NAMES32
#endif
};
static FARPROC export_procs[_countof(export_names)];

bool real_dll_init(void)
{
        TCHAR path[MAX_PATH];

        if ( !hmod ) {
                GetSystemDirectory(path, _countof(path));
                _tcscat_s(path, _countof(path), _T(DLL_FNAME));
                hmod = LoadLibrary(path);
        }
        return !!hmod;
}

bool real_dll_free(void)
{
        bool result = false;

        if ( !hmod )
                return result;

        if ( FreeLibrary(hmod) ) {
                hmod = NULL;
                result = true;
        }

        return result;
}

FARPROC resolve_export_proc(size_t index)
{
        if ( index < _countof(export_names)
                && index < _countof(export_procs) ) {
                if ( hmod && export_procs[index] )
                        return export_procs[index];

                if ( real_dll_init() )
                        return export_procs[index] = GetProcAddress(hmod, export_names[index]);
        }
        return NULL;
}
