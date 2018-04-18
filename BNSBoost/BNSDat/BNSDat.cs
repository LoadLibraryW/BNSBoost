using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BNSBoost.BNSDat
{
    public class BNSDat
    {
        public const string AES_KEY = "bns_obt_kr_2014#";
        public static readonly byte[] XOR_KEY = { 164, 159, 216, 179, 246, 142, 57, 194, 45, 224, 97, 117, 92, 75, 26, 7 };

        private static byte[] Decrypt(byte[] buffer, int size)
        {
            // AES requires buffer to consist of blocks with 16 bytes (each)
            // expand last block by padding zeros if required...
            // -> the encrypted data in BnS seems already to be aligned to blocks
            int AES_BLOCK_SIZE = AES_KEY.Length;
            int sizePadded = size + AES_BLOCK_SIZE;
            byte[] output = new byte[sizePadded];
            byte[] tmp = new byte[sizePadded];
            buffer.CopyTo(tmp, 0);

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            ICryptoTransform decrypt = aes.CreateDecryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            decrypt.TransformBlock(tmp, 0, sizePadded, output, 0);
            tmp = output;
            output = new byte[size];
            Array.Copy(tmp, 0, output, 0, size);

            return output;
        }

        private static byte[] Inflate(byte[] buffer, int sizeDecompressed)
        {
            byte[] tmp = Ionic.Zlib.ZlibStream.UncompressBuffer(buffer);

            if (tmp.Length != sizeDecompressed)
            {
                byte[] tmp2 = new byte[sizeDecompressed];

                if (tmp.Length > sizeDecompressed)
                    Array.Copy(tmp, 0, tmp2, 0, sizeDecompressed);
                else
                    Array.Copy(tmp, 0, tmp2, 0, tmp.Length);
                tmp = tmp2;
            }
            return tmp;
        }

        private static byte[] Unpack(byte[] buffer, int sizeStored, int sizeSheared, int sizeUnpacked, bool isEncrypted, bool isCompressed)
        {
            byte[] output = buffer;

            if (isEncrypted)
            {
                output = Decrypt(output, sizeStored);
            }

            if (isCompressed)
            {
                output = Inflate(output, sizeUnpacked);
            }

            // neither encrypted, nor compressed -> raw copy
            if (output == buffer)
            {
                output = new byte[sizeUnpacked];
                if (sizeSheared < sizeUnpacked)
                {
                    Array.Copy(buffer, 0, output, 0, sizeSheared);
                }
                else
                {
                    Array.Copy(buffer, 0, output, 0, sizeUnpacked);
                }
            }

            return output;
        }

        private static byte[] Deflate(byte[] buffer, int sizeDecompressed, out int sizeCompressed, int compressionLevel)
        {
            MemoryStream output = new MemoryStream();
            Ionic.Zlib.ZlibStream zs = new Ionic.Zlib.ZlibStream(output, Ionic.Zlib.CompressionMode.Compress, (Ionic.Zlib.CompressionLevel)compressionLevel, true);
            zs.Write(buffer, 0, sizeDecompressed);
            zs.Flush();
            zs.Close();
            sizeCompressed = (int)output.Length;
            return output.ToArray();
        }

        private static byte[] Encrypt(byte[] buffer, int size, out int sizePadded)
        {
            int AES_BLOCK_SIZE = AES_KEY.Length;
            sizePadded = size + (AES_BLOCK_SIZE - (size % AES_BLOCK_SIZE));
            byte[] output = new byte[sizePadded];
            byte[] temp = new byte[sizePadded];
            Array.Copy(buffer, 0, temp, 0, buffer.Length);

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;

            ICryptoTransform encrypt = aes.CreateEncryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            encrypt.TransformBlock(temp, 0, sizePadded, output, 0);
            return output;
        }

        private static byte[] Pack(byte[] buffer, int sizeUnpacked, out int sizeSheared, out int sizeStored, bool encrypt, bool compress, int compressionLevel)
        {
            byte[] output = buffer;
            sizeSheared = sizeUnpacked;
            sizeStored = sizeSheared;

            if (compress)
            {
                sizeStored = sizeSheared;
                output = Deflate(output, sizeUnpacked, out sizeSheared, compressionLevel);
            }

            if (encrypt)
            {
                output = Encrypt(output, sizeSheared, out sizeStored);
            }

            return output;
        }

        public static void Extract(string FileName, Action<int, int> processedEvent, bool is64 = false)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            byte[] Signature = br.ReadBytes(8);
            uint Version = br.ReadUInt32();

            byte[] Unknown_001 = br.ReadBytes(5);
            int FileDataSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileCount = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            bool IsCompressed = br.ReadByte() == 1;
            bool IsEncrypted = br.ReadByte() == 1;
            byte[] Unknown_002 = br.ReadBytes(62);
            int FileTableSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileTableSizeUnpacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();

            buffer_packed = br.ReadBytes(FileTableSizePacked);
            int OffsetGlobal = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            OffsetGlobal = (int)br.BaseStream.Position; // don't trust value, read current stream location.

            byte[] FileTableUnpacked = Unpack(buffer_packed, FileTableSizePacked, FileTableSizePacked, FileTableSizeUnpacked, IsEncrypted, IsCompressed);

            MemoryStream ms = new MemoryStream(FileTableUnpacked);
            BinaryReader br2 = new BinaryReader(ms);

            for (int i = 0; i < FileCount; i++)
            {
                int pathLength = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                BPKG_FTE FileTableEntry = new BPKG_FTE
                {
                    FilePathLength = pathLength,
                    FilePath = Encoding.Unicode.GetString(br2.ReadBytes(pathLength * 2)),
                    Unknown_001 = br2.ReadByte(),
                    IsCompressed = br2.ReadByte() == 1,
                    IsEncrypted = br2.ReadByte() == 1,
                    Unknown_002 = br2.ReadByte(),
                    FileDataSizeUnpacked = is64 ? (int)br2.ReadInt64() : br2.ReadInt32(),
                    FileDataSizeSheared = is64 ? (int)br2.ReadInt64() : br2.ReadInt32(),
                    FileDataSizeStored = is64 ? (int)br2.ReadInt64() : br2.ReadInt32(),
                    FileDataOffset = (is64 ? (int)br2.ReadInt64() : br2.ReadInt32()) + OffsetGlobal,
                    Padding = br2.ReadBytes(60)

                };

                file_path = $"{FileName}.files\\{FileTableEntry.FilePath}";
                if (!Directory.Exists(new FileInfo(file_path).DirectoryName))
                    Directory.CreateDirectory(new FileInfo(file_path).DirectoryName);

                br.BaseStream.Position = FileTableEntry.FileDataOffset;
                buffer_packed = br.ReadBytes(FileTableEntry.FileDataSizeStored);
                buffer_unpacked = Unpack(buffer_packed, FileTableEntry.FileDataSizeStored, FileTableEntry.FileDataSizeSheared, FileTableEntry.FileDataSizeUnpacked, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed);

                if (file_path.EndsWith("xml") || file_path.EndsWith("x16"))
                {
                    // decode bxml
                    using (MemoryStream output = new MemoryStream())
                    using (MemoryStream input = new MemoryStream(buffer_unpacked))
                    {
                        Convert(input, BXML.DetectType(input), output, BXML_TYPE.BXML_PLAIN);

                        using (WinFileIO writer = new WinFileIO(output.ToArray()))
                        {
                            writer.OpenForWriting(file_path);
                            writer.WriteBlocks((int)output.Length);
                        }

                        //File.WriteAllBytes(file_path, temp.ToArray());
                    }
                }
                else
                {
                    // extract raw
                    File.WriteAllBytes(file_path, buffer_unpacked);
                }
                processedEvent(i + 1, FileCount);
            }


            br2.Close();
            ms.Close();
            br.Close();
            fs.Close();
        }

        public static void Compress(string Folder, Action<int, int> progress, bool is64 = false, int compression = 1)
        {
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            string[] files = Directory.EnumerateFiles(Folder, "*", SearchOption.AllDirectories).ToArray();

            int FileCount = files.Count();

            BPKG_FTE FileTableEntry = new BPKG_FTE();
            MemoryStream mosTablems = new MemoryStream();
            BinaryWriter mosTable = new BinaryWriter(mosTablems);
            MemoryStream mosFilesms = new MemoryStream();
            BinaryWriter mosFiles = new BinaryWriter(mosFilesms);

            for (int i = 0; i < FileCount; i++)
            {
                progress(i + 1, FileCount);
                file_path = files[i].Replace(Folder, "").TrimStart('\\');
                FileTableEntry.FilePathLength = file_path.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FilePathLength);
                else
                    mosTable.Write(FileTableEntry.FilePathLength);

                FileTableEntry.FilePath = file_path;
                mosTable.Write(Encoding.Unicode.GetBytes(FileTableEntry.FilePath));
                FileTableEntry.Unknown_001 = 2;
                mosTable.Write(FileTableEntry.Unknown_001);
                FileTableEntry.IsCompressed = true;
                mosTable.Write(FileTableEntry.IsCompressed);
                FileTableEntry.IsEncrypted = true;
                mosTable.Write(FileTableEntry.IsEncrypted);
                FileTableEntry.Unknown_002 = 0;
                mosTable.Write(FileTableEntry.Unknown_002);

                FileStream fis = new FileStream(files[i], FileMode.Open, FileAccess.ReadWrite, FileShare.Read, 2 << 15);
                MemoryStream tmp = new MemoryStream();

                if (file_path.EndsWith(".xml") || file_path.EndsWith(".x16"))
                {
                    // encode bxml
                    Convert(fis, BXML.DetectType(fis), tmp, BXML_TYPE.BXML_BINARY);
                }
                else
                {
                    // compress raw
                    fis.CopyTo(tmp);
                }
                fis.Close();
                fis = null;

                FileTableEntry.FileDataOffset = (int)mosFiles.BaseStream.Position;
                FileTableEntry.FileDataSizeUnpacked = (int)tmp.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeUnpacked);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeUnpacked);

                buffer_unpacked = tmp.ToArray();
                tmp.Close();
                tmp = null;
                buffer_packed = Pack(buffer_unpacked, FileTableEntry.FileDataSizeUnpacked, out FileTableEntry.FileDataSizeSheared, out FileTableEntry.FileDataSizeStored, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed, compression);
                buffer_unpacked = null;
                mosFiles.Write(buffer_packed);
                buffer_packed = null;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeSheared);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeSheared);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeStored);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeStored);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataOffset);
                else
                    mosTable.Write(FileTableEntry.FileDataOffset);

                FileTableEntry.Padding = new byte[60];
                mosTable.Write(FileTableEntry.Padding);
            }


            MemoryStream output = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(output);
            byte[] Signature = new byte[8] { (byte)'U', (byte)'O', (byte)'S', (byte)'E', (byte)'D', (byte)'A', (byte)'L', (byte)'B' };
            bw.Write(Signature);
            int Version = 2;
            bw.Write(Version);
            byte[] Unknown_001 = new byte[5] { 0, 0, 0, 0, 0 };
            bw.Write(Unknown_001);
            int FileDataSizePacked = (int)mosFiles.BaseStream.Length;

            if (is64)
            {
                bw.Write((long)FileDataSizePacked);
                bw.Write((long)FileCount);
            }
            else
            {
                bw.Write(FileDataSizePacked);
                bw.Write(FileCount);
            }

            bool IsCompressed = true;
            bw.Write(IsCompressed);
            bool IsEncrypted = true;
            bw.Write(IsEncrypted);
            byte[] Unknown_002 = new byte[62];
            bw.Write(Unknown_002);

            int FileTableSizeUnpacked = (int)mosTable.BaseStream.Length;
            int FileTableSizeSheared = FileTableSizeUnpacked;
            int FileTableSizePacked = FileTableSizeUnpacked;
            buffer_unpacked = mosTablems.ToArray();
            mosTable.Close();
            mosTablems.Close();
            mosTable = null;
            mosTablems = null;
            buffer_packed = Pack(buffer_unpacked, FileTableSizeUnpacked, out FileTableSizeSheared, out FileTableSizePacked, IsEncrypted, IsCompressed, compression);
            buffer_unpacked = null;

            if (is64)
                bw.Write((long)FileTableSizePacked);
            else
                bw.Write(FileTableSizePacked);

            if (is64)
                bw.Write((long)FileTableSizeUnpacked);
            else
                bw.Write(FileTableSizeUnpacked);

            bw.Write(buffer_packed);
            buffer_packed = null;

            int OffsetGlobal = (int)output.Position + (is64 ? 8 : 4);

            if (is64)
                bw.Write((long)OffsetGlobal);
            else
                bw.Write(OffsetGlobal);

            buffer_packed = mosFilesms.ToArray();
            mosFiles.Close();
            mosFilesms.Close();
            mosFiles = null;
            mosFilesms = null;
            bw.Write(buffer_packed);
            buffer_packed = null;

            WinFileIO writer = new WinFileIO(output.ToArray());
            writer.OpenForWriting(Folder.Replace(".files", ""));
            writer.WriteBlocks((int)output.Length);
            writer.Close();

            //File.WriteAllBytes(Folder.Replace(".files", ""), output.ToArray());

            bw.Close();
            output.Close();
            bw = null;
            output = null;
        }

        private static void Convert(Stream iStream, BXML_TYPE iType, Stream oStream, BXML_TYPE oType)
        {
            if ((iType == BXML_TYPE.BXML_PLAIN && oType == BXML_TYPE.BXML_BINARY) || (iType == BXML_TYPE.BXML_BINARY && oType == BXML_TYPE.BXML_PLAIN))
            {
                BXML bns_xml = new BXML(XOR_KEY);
                bns_xml.Load(iStream, iType);
                bns_xml.Save(oStream, oType);
            }
            else
            {
                iStream.CopyTo(oStream);
            }
        }
    }
}
