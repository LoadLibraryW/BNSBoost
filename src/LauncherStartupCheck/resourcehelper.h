#pragma once

typedef struct
{
        WORD wLanguage;
        WORD wCodePage;
} LANGANDCODEPAGE, *PLANGANDCODEPAGE;

void *rsrc_get_version_info(HMODULE hModule);

wchar_t *rsrc_query_string_file_info(const void *pBlock,
        LANGANDCODEPAGE lcp,
        const wchar_t *pszStringName,
        size_t *pcchLength);

PLANGANDCODEPAGE rsrc_query_var_file_info(const void *pBlock, size_t *pCount);

VS_FIXEDFILEINFO *rsrc_query_fixed_file_info(const void *pBlock);
