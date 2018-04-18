namespace BNSBoost.BNSDat
{
    class BPKG_FTE
    {
        public int FilePathLength;
        public string FilePath;
        public byte Unknown_001;
        public bool IsCompressed;
        public bool IsEncrypted;
        public byte Unknown_002;
        public int FileDataSizeUnpacked;
        public int FileDataSizeSheared; // without padding for AES
        public int FileDataSizeStored;
        public int FileDataOffset; // (relative) offset
        public byte[] Padding;

    }
}