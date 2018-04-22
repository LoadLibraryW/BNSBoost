#pragma once

#ifndef _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <Windows.h>
#include <string>

namespace XignCode
{
	#define XIGNAPI __stdcall

	enum FUNCTION_DISPATCH_TYPE
	{
		FDT_INITIALIZE			= 1,	// 0x01
		FDT_UNINITIALIZE		= 2,	// 0x02

		FDT_START_SERVICE		= 3,	// 0x03
		FDT_STOP_SERVICE		= 4,	// 0x04

		FDT_MAKE_RESPONSE		= 6,	// 0x06
		
		FDT_SET_ERROR_CALLBACK	= 22,	// 0x16
		FDT_SET_OPTION			= 26,	// 0x1A
	};
	
	enum _XclioFid
	{
		XclioFidSysEnterA = 0x0,
		XclioFidSysEnterW = 0x1,
		XclioFidSysExit = 0x2,
		XclioFidInit = 0x3,
		XclioFidCleanup = 0x4,
		XclioFidProbe = 0x5,
		XclioFidProbeEx = 0x6,
		XclioFidCreateCodeBox = 0x7,
		XclioFidCloseCodeBox = 0x8,
		XclioFidProbeCodeBox = 0x9,
		XclioFidProbeCodeBoxEx = 0xA,
		XclioFidEncrypt = 0xB,
		XclioFidDecrypt = 0xC,
		XclioFidRsaCreate = 0xD,
		XclioFidRsaClose = 0xE,
		XclioFidRsaSetPublicKey = 0xF,
		XclioFidRsaSetPrivateKey = 0x10,
		XclioFidRsaPublicEncrypt = 0x11,
		XclioFidRsaPublicDecrypt = 0x12,
		XclioFidRsaPrivateEncrypt = 0x13,
		XclioFidRsaPrivateDecrypt = 0x14,
		XclioFidCheck = 0x15,
		XclioFidRegisterCallback = 0x16,
		XclioFidRsaGenerateKey = 0x17,
		XclioFidRsaFreeBuffer = 0x18,
		XclioFidSetup = 0x19,
		XclioFidSendCommandVa = 0x1A,
	};

	typedef unsigned int (XIGNAPI* _XignCode_function_dispatch_t)(void** function_ptr, FUNCTION_DISPATCH_TYPE function_type);

	typedef unsigned int (XIGNAPI* _XignCode_heartbeat_callback_t)(void* pointer, unsigned char* response_1, unsigned char* response_2, unsigned int size, int unknown);
	typedef unsigned int (XIGNAPI* _XignCode_error_callback_t)(unsigned int error_code, unsigned int param_size, void* param, void* unknown);
	
	typedef BOOL (XIGNAPI* _XignCode_initialize_t)(const wchar_t* license_key, const wchar_t* xigncode_directory, int unknown);
	typedef BOOL (XIGNAPI* _XignCode_uninitialize_t)();

	typedef BOOL (XIGNAPI* _XignCode_start_service_t)();
	typedef BOOL (XIGNAPI* _XignCode_stop_service_t)();

	typedef BOOL (XIGNAPI* _XignCode_make_response_t)(unsigned char* request, unsigned int size, _XignCode_heartbeat_callback_t response_callback, int unknown);
	typedef BOOL (XIGNAPI* _XignCode_set_error_callback_t)(_XignCode_error_callback_t error_callback, void* unknown);
}