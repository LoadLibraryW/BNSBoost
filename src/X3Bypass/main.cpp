#pragma once
#ifndef UNICODE
#define UNICODE
#endif

#include <Windows.h>
#include <stdio.h>

BOOL APIENTRY DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	if (fdwReason == DLL_PROCESS_ATTACH)
	{
#ifdef _DEBUG
		AllocConsole();
		SetConsoleTitle(L"XignCode Client");
		AttachConsole(GetCurrentProcessId());
	
		FILE* pFile = nullptr;
		freopen_s(&pFile, "CON", "r", stdin);
		freopen_s(&pFile, "CON", "w", stdout);
		freopen_s(&pFile, "CON", "w", stderr);
#endif
		DisableThreadLibraryCalls(hinstDLL);
	}
	else if (fdwReason == DLL_PROCESS_DETACH)
	{
#ifdef _DEBUG
		FreeConsole();
#endif
	}

	return TRUE;
}