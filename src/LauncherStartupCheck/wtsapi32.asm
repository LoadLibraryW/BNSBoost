ifndef x64
        .model flat, stdcall
        .safeseh SEH_handler
endif

.code

ifndef x64
        resolve_export_proc proto C, arg1:dword
else
        extern resolve_export_proc:proc
endif

M_EXPORT_PROC macro export, index
export proc
ifndef x64
        invoke resolve_export_proc, index
        jmp dword ptr eax
else
        push rcx
        push rdx
        push r8
        push r9
        sub rsp, 28h
if index eq 0
        xor rcx, rcx
else
        mov rcx, index
endif
        call resolve_export_proc
        add rsp, 28h
        pop r9
        pop r8
        pop rdx
        pop rcx
        jmp qword ptr rax
endif
export endp
endm

M_EXPORT_PROC WTSCloseServer, 0
M_EXPORT_PROC WTSConnectSessionA, 1
M_EXPORT_PROC WTSConnectSessionW, 2
M_EXPORT_PROC WTSCreateListenerA, 3
M_EXPORT_PROC WTSCreateListenerW, 4
M_EXPORT_PROC WTSDisconnectSession, 5
M_EXPORT_PROC WTSEnumerateListenersA, 6
M_EXPORT_PROC WTSEnumerateListenersW, 7
M_EXPORT_PROC WTSEnumerateProcessesA, 8
M_EXPORT_PROC WTSEnumerateProcessesExA, 9
M_EXPORT_PROC WTSEnumerateProcessesExW, 10
M_EXPORT_PROC WTSEnumerateProcessesW, 11
M_EXPORT_PROC WTSEnumerateServersA, 12
M_EXPORT_PROC WTSEnumerateServersW, 13
M_EXPORT_PROC WTSEnumerateSessionsA, 14
M_EXPORT_PROC WTSEnumerateSessionsExA, 15
M_EXPORT_PROC WTSEnumerateSessionsExW, 16
M_EXPORT_PROC WTSEnumerateSessionsW, 17
M_EXPORT_PROC WTSFreeMemory, 18
M_EXPORT_PROC WTSFreeMemoryExA, 19
M_EXPORT_PROC WTSFreeMemoryExW, 20
M_EXPORT_PROC WTSGetListenerSecurityA, 21
M_EXPORT_PROC WTSGetListenerSecurityW, 22
M_EXPORT_PROC WTSLogoffSession, 23
M_EXPORT_PROC WTSOpenServerA, 24
M_EXPORT_PROC WTSOpenServerExA, 25
M_EXPORT_PROC WTSOpenServerExW, 26
M_EXPORT_PROC WTSOpenServerW, 27
M_EXPORT_PROC WTSQueryListenerConfigA, 28
M_EXPORT_PROC WTSQueryListenerConfigW, 29
M_EXPORT_PROC WTSQuerySessionInformationA, 30
M_EXPORT_PROC WTSQuerySessionInformationW, 31
M_EXPORT_PROC WTSQueryUserConfigA, 32
M_EXPORT_PROC WTSQueryUserConfigW, 33
M_EXPORT_PROC WTSQueryUserToken, 34
M_EXPORT_PROC WTSRegisterSessionNotification, 35
M_EXPORT_PROC WTSRegisterSessionNotificationEx, 36
M_EXPORT_PROC WTSSendMessageA, 37
M_EXPORT_PROC WTSSendMessageW, 38
M_EXPORT_PROC WTSSetListenerSecurityA, 39
M_EXPORT_PROC WTSSetListenerSecurityW, 40
M_EXPORT_PROC WTSSetSessionInformationA, 41
M_EXPORT_PROC WTSSetSessionInformationW, 42
M_EXPORT_PROC WTSSetUserConfigA, 43
M_EXPORT_PROC WTSSetUserConfigW, 44
M_EXPORT_PROC WTSShutdownSystem, 45
M_EXPORT_PROC WTSStartRemoteControlSessionA, 46
M_EXPORT_PROC WTSStartRemoteControlSessionW, 47
M_EXPORT_PROC WTSStopRemoteControlSession, 48
M_EXPORT_PROC WTSTerminateProcess, 49
M_EXPORT_PROC WTSUnRegisterSessionNotification, 50
M_EXPORT_PROC WTSUnRegisterSessionNotificationEx, 51
M_EXPORT_PROC WTSVirtualChannelClose, 52
M_EXPORT_PROC WTSVirtualChannelOpen, 53
M_EXPORT_PROC WTSVirtualChannelOpenEx, 54
M_EXPORT_PROC WTSVirtualChannelPurgeInput, 55
M_EXPORT_PROC WTSVirtualChannelPurgeOutput, 56
M_EXPORT_PROC WTSVirtualChannelQuery, 57
M_EXPORT_PROC WTSVirtualChannelRead, 58
M_EXPORT_PROC WTSVirtualChannelWrite, 59
M_EXPORT_PROC WTSWaitSystemEvent, 60

SEH_handler   proc
        ; empty handler
        ret
SEH_handler   endp

end
