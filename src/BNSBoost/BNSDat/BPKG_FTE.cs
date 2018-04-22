using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace BNSBoost.BNSDat
{
    class BPKG_FTE
    {
        public BPKG Pkg;
        public int FilePathLength;
        public string FilePath;
        public bool IsCompressed;
        public bool IsEncrypted;
        public int FileDataSizeUnpacked;
        public int FileDataSizeSheared; // without padding for AES
        public int FileDataSizeStored;
        public long FileDataOffset; // (relative) offset

        public BPKG_FTE(Stream stream, BPKG pkg)
        {
            Pkg = pkg;
            bool is64 = pkg.Is64;

            BinaryReader fte = new BinaryReader(stream);

            FilePathLength = is64 ? (int)fte.ReadInt64() : fte.ReadInt32();
            FilePath = Encoding.Unicode.GetString(fte.ReadBytes(FilePathLength * 2));
            fte.ReadByte(); // Unknown
            IsCompressed = fte.ReadBoolean();
            IsEncrypted = fte.ReadBoolean();
            fte.ReadByte(); // Unknown
            FileDataSizeUnpacked = is64 ? (int)fte.ReadInt64() : fte.ReadInt32();
            FileDataSizeSheared = is64 ? (int)fte.ReadInt64() : fte.ReadInt32();
            FileDataSizeStored = is64 ? (int)fte.ReadInt64() : fte.ReadInt32();
            FileDataOffset = (is64 ? fte.ReadInt64() : fte.ReadInt32()) + pkg.BaseOffset;
            fte.ReadBytes(60); // Padding
        }

        public BPKG_FTE()
        {
        }

        public void WriteTo(Stream stream, bool is64)
        {
            BinaryWriter fte = new BinaryWriter(stream);

            if (is64)
                fte.Write((long)FilePathLength);
            else
                fte.Write(FilePathLength);

            fte.Write(Encoding.Unicode.GetBytes(FilePath));
            fte.Write((byte)2); // Unknown
            fte.Write(IsCompressed);
            fte.Write(IsEncrypted);
            fte.Write((byte)0); // Unknown

            if (is64)
                fte.Write((long)FileDataSizeUnpacked);
            else
                fte.Write((int)FileDataSizeUnpacked);

            if (is64)
                fte.Write((long)FileDataSizeSheared);
            else
                fte.Write((int)FileDataSizeSheared);

            if (is64)
                fte.Write((long)FileDataSizeStored);
            else
                fte.Write((int)FileDataSizeStored);

            if (is64)
                fte.Write((long)FileDataOffset);
            else
                fte.Write((int)FileDataOffset);

            fte.Write(new byte[60]); // Padding
        }
    }
}