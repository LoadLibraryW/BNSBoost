Originally from https://github.com/VirtualPuppet/XignCode3-bypass

---

# XignCode3 bypass
A host-based emulator bypass for Wellbia's XignCode3.

Emulates the integrity-check for XignCode3 through a host-application.

* A host application launches/initializes XignCode3, causing XignCode3 to run its anti-hack analysis in that particular process-space, resulting in hack-attempts on the original application to remain undetected.
* A client application hijacks the XignCode3 files (and exports), forwarding all integry-check requests to the host-application (through a local socket) to generate verification-responses.
