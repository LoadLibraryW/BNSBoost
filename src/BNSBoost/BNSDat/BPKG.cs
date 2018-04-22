using System.IO;

namespace BNSBoost.BNSDat
{
    class BPKG
    {
        public bool Is64;
        public byte[] Signature;
        public uint Version;
        public long PackedFileDataSize;
        public long FileCount;
        public bool IsCompressed;
        public bool IsEncrypted;
        public long PackedFileEntryTableSize;
        public long UnpackedFileEntryTableSize;
        public long BaseOffset;
        public BPKG_FTE[] Files;

        public BPKG(Stream stream, bool is64)
        {
            Is64 = is64;

            BinaryReader br = new BinaryReader(stream);

            Signature = br.ReadBytes(8);
            Version = br.ReadUInt32();
            br.ReadBytes(5); // Unknown
            PackedFileDataSize = is64 ? br.ReadInt64() : br.ReadInt32();
            FileCount = is64 ? br.ReadInt64() : br.ReadInt32();
            IsCompressed = br.ReadBoolean();
            IsEncrypted = br.ReadBoolean();
            br.ReadBytes(62); // Unknown
            PackedFileEntryTableSize = is64 ? br.ReadInt64() : br.ReadInt32();
            UnpackedFileEntryTableSize = is64 ? br.ReadInt64() : br.ReadInt32();
            byte[] packedFileEntryTable = br.ReadBytes((int)PackedFileEntryTableSize);

            BaseOffset = is64 ? br.ReadInt64() : br.ReadInt32();
            BaseOffset = br.BaseStream.Position; // don't trust value, read current stream location.

            // PackedFileData = br.ReadBytes((int)PackedFileDataSize);

            byte[] unpackedFileEntryTable = BNSDat.Unpack(packedFileEntryTable, packedFileEntryTable.Length, packedFileEntryTable.Length, UnpackedFileEntryTableSize, IsEncrypted, IsCompressed);

            Files = new BPKG_FTE[FileCount];

            MemoryStream ms = new MemoryStream(unpackedFileEntryTable);
            for (int i = 0; i < FileCount; i++)
            {
                Files[i] = new BPKG_FTE(ms, this);
            }
        }
    }
}