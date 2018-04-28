#pragma once


#define DLL_FNAME "\\wtsapi32.dll"
#define EXPORT_NAMES \
        "WTSCloseServer", \
        "WTSConnectSessionA", \
        "WTSConnectSessionW", \
        "WTSCreateListenerA", \
        "WTSCreateListenerW", \
        "WTSDisconnectSession", \
        "WTSEnumerateListenersA", \
        "WTSEnumerateListenersW", \
        "WTSEnumerateProcessesA", \
        "WTSEnumerateProcessesExA", \
        "WTSEnumerateProcessesExW", \
        "WTSEnumerateProcessesW", \
        "WTSEnumerateServersA", \
        "WTSEnumerateServersW", \
        "WTSEnumerateSessionsA", \
        "WTSEnumerateSessionsExA", \
        "WTSEnumerateSessionsExW", \
        "WTSEnumerateSessionsW", \
        "WTSFreeMemory", \
        "WTSFreeMemoryExA", \
        "WTSFreeMemoryExW", \
        "WTSGetListenerSecurityA", \
        "WTSGetListenerSecurityW", \
        "WTSLogoffSession", \
        "WTSOpenServerA", \
        "WTSOpenServerExA", \
        "WTSOpenServerExW", \
        "WTSOpenServerW", \
        "WTSQueryListenerConfigA", \
        "WTSQueryListenerConfigW", \
        "WTSQuerySessionInformationA", \
        "WTSQuerySessionInformationW", \
        "WTSQueryUserConfigA", \
        "WTSQueryUserConfigW", \
        "WTSQueryUserToken", \
        "WTSRegisterSessionNotification", \
        "WTSRegisterSessionNotificationEx", \
        "WTSSendMessageA", \
        "WTSSendMessageW", \
        "WTSSetListenerSecurityA", \
        "WTSSetListenerSecurityW", \
        "WTSSetSessionInformationA", \
        "WTSSetSessionInformationW", \
        "WTSSetUserConfigA", \
        "WTSSetUserConfigW", \
        "WTSShutdownSystem", \
        "WTSStartRemoteControlSessionA", \
        "WTSStartRemoteControlSessionW", \
        "WTSStopRemoteControlSession", \
        "WTSTerminateProcess", \
        "WTSUnRegisterSessionNotification", \
        "WTSUnRegisterSessionNotificationEx", \
        "WTSVirtualChannelClose", \
        "WTSVirtualChannelOpen", \
        "WTSVirtualChannelOpenEx", \
        "WTSVirtualChannelPurgeInput", \
        "WTSVirtualChannelPurgeOutput", \
        "WTSVirtualChannelQuery", \
        "WTSVirtualChannelRead", \
        "WTSVirtualChannelWrite", \
        "WTSWaitSystemEvent"

bool real_dll_init(void);
bool real_dll_free(void);
FARPROC resolve_export_proc(size_t index);
