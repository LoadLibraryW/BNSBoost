using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BNSBoost.BNSDat
{
    public partial class BNSDat
    {
        public const string AES_KEY = "bns_obt_kr_2014#";
        public static readonly byte[] XOR_KEY = { 164, 159, 216, 179, 246, 142, 57, 194, 45, 224, 97, 117, 92, 75, 26, 7 };

        private static byte[] Encrypt(byte[] buffer, int size, out int sizePadded)
        {
            int AES_BLOCK_SIZE = AES_KEY.Length;
            sizePadded = size + (AES_BLOCK_SIZE - size % AES_BLOCK_SIZE);

            byte[] encrypted = new byte[sizePadded];
            byte[] paddedBuffer = new byte[sizePadded];
            buffer.CopyTo(paddedBuffer, 0);

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            ICryptoTransform encrypt = aes.CreateEncryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            encrypt.TransformBlock(paddedBuffer, 0, sizePadded, encrypted, 0);

            return encrypted;
        }

        private static byte[] Decrypt(byte[] buffer, long size)
        {
            // AES requires buffer to consist of blocks with 16 bytes (each)
            // expand last block by padding zeros if required...
            // -> the encrypted data in BnS seems already to be aligned to blocks
            int AES_BLOCK_SIZE = AES_KEY.Length;
            long sizePadded = size + AES_BLOCK_SIZE;
            byte[] output = new byte[sizePadded];
            byte[] paddedBuffer = new byte[sizePadded];
            buffer.CopyTo(paddedBuffer, 0);

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            ICryptoTransform decrypt = aes.CreateDecryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            decrypt.TransformBlock(paddedBuffer, 0, (int)sizePadded, output, 0);

            byte[] decrypted = new byte[size];
            Array.Copy(output, 0, decrypted, 0, size);
            return decrypted;
        }

        private static byte[] Inflate(byte[] buffer, long sizeDecompressed)
        {
            byte[] decompressed = Ionic.Zlib.ZlibStream.UncompressBuffer(buffer);

            if (decompressed.Length != sizeDecompressed)
            {
                byte[] truncated = new byte[sizeDecompressed];
                Array.Copy(decompressed, 0, truncated, 0, Math.Min(sizeDecompressed, decompressed.Length));
                decompressed = truncated;
            }

            return decompressed;
        }

        private static byte[] Deflate(byte[] buffer, int sizeDecompressed, out int sizeCompressed, int compressionLevel)
        {
            MemoryStream output = new MemoryStream();

            using (Ionic.Zlib.ZlibStream zs = new Ionic.Zlib.ZlibStream(output, Ionic.Zlib.CompressionMode.Compress, (Ionic.Zlib.CompressionLevel)compressionLevel, true))
                zs.Write(buffer, 0, sizeDecompressed);

            sizeCompressed = (int)output.Length;
            return output.ToArray();
        }

        private static byte[] Pack(byte[] buffer, out int sizeSheared, out int sizeStored, bool encrypt, bool compress, int compressionLevel)
        {
            sizeSheared = buffer.Length;
            sizeStored = sizeSheared;

            if (compress)
            {
                sizeStored = sizeSheared;
                buffer = Deflate(buffer, buffer.Length, out sizeSheared, compressionLevel);
            }

            if (encrypt)
            {
                buffer = Encrypt(buffer, sizeSheared, out sizeStored);
            }

            return buffer;
        }

        public static byte[] Unpack(byte[] buffer, long sizeStored, long sizeSheared, long sizeUnpacked, bool isEncrypted, bool isCompressed)
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
            if (!isEncrypted && !isCompressed)
            {
                output = new byte[sizeUnpacked];
                Array.Copy(buffer, 0, output, 0, Math.Min(sizeSheared, sizeUnpacked));
            }

            return output;
        }

        public static void Extract(string FileName, Action<int, int> processedEvent, bool is64 = false)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);

                BPKG pkg = new BPKG(fs, is64);

                for (var i = 0; i < pkg.Files.Length; i++)
                {
                    BPKG_FTE fte = pkg.Files[i];
                    // Seek to location of binary file data
                    fs.Position = fte.FileDataOffset;

                    byte[] packedFileData = br.ReadBytes(fte.FileDataSizeStored);
                    byte[] unpackedFileData = Unpack(packedFileData, fte.FileDataSizeStored,
                        fte.FileDataSizeSheared, fte.FileDataSizeUnpacked,
                        fte.IsEncrypted, fte.IsCompressed);

                    string extractedPath = $"{FileName}.files\\{fte.FilePath}";
                    string extractedDir = new FileInfo(extractedPath).DirectoryName;
                    if (!Directory.Exists(extractedDir));
                        Directory.CreateDirectory(extractedDir);

                    if (extractedPath.EndsWith("xml") || extractedPath.EndsWith("x16"))
                    {
                        // decode bxml
                        MemoryStream output = new MemoryStream();
                        MemoryStream input = new MemoryStream(unpackedFileData);

                        Convert(input, BXML.DetectType(input), output, BXML_TYPE.BXML_PLAIN);

                        using (WinFileIO writer = new WinFileIO(output.ToArray()))
                        {
                            writer.OpenForWriting(extractedPath);
                            writer.WriteBlocks((int)output.Length);
                        }
                    }
                    else
                    {
                        // extract raw
                        File.WriteAllBytes(extractedPath, unpackedFileData);
                    }
                    processedEvent(i + 1, pkg.Files.Length);
                }
            }
        }

        public static void Compress(string Folder, Action<int, int> reportProgress, bool is64 = false, int compression = 1)
        {
            string[] files = Directory.EnumerateFiles(Folder, "*", SearchOption.AllDirectories).ToArray();

            MemoryStream fileTableEntriesStream = new MemoryStream();
            MemoryStream fileTableStream = new MemoryStream();

            for (var i = 0; i < files.Length; i++)
            {
                reportProgress(i + 1, files.Length);

                string path = files[i].Replace(Folder, "").TrimStart('\\');

                byte[] unpackedFileBuffer;
                using (FileStream fis = new FileStream(files[i], FileMode.Open, FileAccess.ReadWrite, FileShare.Read, 2 << 15))
                using (MemoryStream buf = new MemoryStream())
                {
                    if (path.EndsWith(".xml") || path.EndsWith(".x16"))
                    {
                        // encode bxml
                        Convert(fis, BXML.DetectType(fis), buf, BXML_TYPE.BXML_BINARY);
                    }
                    else
                    {
                        // compress raw
                        fis.CopyTo(buf);
                    }

                    unpackedFileBuffer = buf.ToArray();
                }

                BPKG_FTE entry = new BPKG_FTE
                {
                    FilePathLength = path.Length,
                    FilePath = path,
                    IsCompressed = true,
                    IsEncrypted = true,
                    FileDataOffset = (int)fileTableStream.Position,
                    FileDataSizeUnpacked = unpackedFileBuffer.Length

                };

                byte[] packedFileBuffer = Pack(unpackedFileBuffer, out entry.FileDataSizeSheared, out entry.FileDataSizeStored, entry.IsEncrypted, entry.IsCompressed, compression);
                fileTableStream.Write(packedFileBuffer, 0, packedFileBuffer.Length);

                entry.WriteTo(fileTableEntriesStream, is64);
            }

            MemoryStream packageStream = new MemoryStream();
            BinaryWriter package = new BinaryWriter(packageStream);
            package.Write(new[]
            {
                (byte) 'U', (byte) 'O', (byte) 'S', (byte) 'E', (byte) 'D', (byte) 'A', (byte) 'L', (byte) 'B'
            }); // Signature
            package.Write(2); // Version
            package.Write(new byte[] { 0, 0, 0, 0, 0 }); // Unknown 1

            if (is64)
            {
                package.Write(fileTableStream.Length);
                package.Write((long)files.Length);
            }
            else
            {
                package.Write((int)fileTableStream.Length);
                package.Write(files.Length);
            }

            package.Write(true); // Is compressed
            package.Write(true); // Is encrypted
            package.Write(new byte[62]); // Unknown 2

            int FTESizePacked;
            byte[] packedFTEBuffer = Pack(fileTableEntriesStream.ToArray(), out _, out FTESizePacked, true, true, compression);

            if (is64)
            {
                package.Write((long)FTESizePacked);
                package.Write(fileTableEntriesStream.Length);
            }
            else
            {
                package.Write(FTESizePacked);
                package.Write((int)fileTableEntriesStream.Length);
            }

            package.Write(packedFTEBuffer);

            int globalOffset = (int)packageStream.Position + (is64 ? 8 : 4);

            if (is64)
                package.Write((long)globalOffset);
            else
                package.Write(globalOffset);

            // Write the packed file data
            package.Write(fileTableStream.ToArray());

            WinFileIO writer = new WinFileIO(packageStream.ToArray());
            writer.OpenForWriting(Folder.Replace(".files", ""));
            writer.WriteBlocks((int)packageStream.Length);
            writer.Close();
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
