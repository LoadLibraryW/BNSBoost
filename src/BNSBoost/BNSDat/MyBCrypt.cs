using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace BNSBoost.BNSDat
{
    class MyBCrypt
    {
        public const ulong FNV_PRIME = 0x01000193;
        public const ulong FNV_SEED = 0x811C9DC5;
        public const int AES_BLOCK_SIZE = 16;
        public readonly byte[] XOR_KEY = { 164, 159, 216, 179, 246, 142, 57, 194, 45, 224, 97, 117, 92, 75, 26, 7 }; // A4 9F D8 B3 F6 8E 39 C2 2D E0 61 75 5C 4B 1A 07
        public readonly string CRYPT_KEY = "bns_obt_kr_2014#";

        public void Xor(byte[] buf)
        {
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] ^= XOR_KEY[i % XOR_KEY.Length];
            }
        }

        public ulong CheckSum(byte[] buf)
        {
            ulong checksum = FNV_SEED;

            for (uint i = 0; i < buf.Length; i++)
            {
                checksum = (checksum ^ buf[i]) * FNV_PRIME;
            }

            return checksum;
        }

        public byte[] Deflate(byte[] buffer, uint sizeCompressed, uint sizeDecompressed)
        {
            byte[] deflated = new byte[sizeDecompressed];
            DeflateStream df = new DeflateStream(new MemoryStream(buffer), CompressionMode.Compress);
            df.Read(deflated, 0, (int)sizeDecompressed);
            return deflated;
        }

        public byte[] Inflate(byte[] buffer, uint sizeDecompressed, uint sizeCompressed, uint compressionLevel)
        {
            byte[] inflated = new byte[sizeCompressed];
            DeflateStream df = new DeflateStream(new MemoryStream(buffer), (CompressionLevel)compressionLevel);
            df.Read(inflated, 0, (int)sizeCompressed);
            return inflated;
        }

        public byte[] Decrypt(byte[] buffer, uint size, uint sizePadded)
        {
            // AES requires buffer to consist of blocks with 16 bytes (each)
            // expand last block by padding zeros if required...
            // -> the encrypted data in BnS seems already to be aligned to blocks
            sizePadded = size + (AES_BLOCK_SIZE - (size % AES_BLOCK_SIZE)) % AES_BLOCK_SIZE;
            byte[] decrypted = new byte[sizePadded];
            byte[] tmp = new byte[sizePadded];

            buffer.CopyTo(tmp, 0);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.ASCII.GetBytes(CRYPT_KEY);
                aesAlg.IV = new byte[16];
                aesAlg.Mode = CipherMode.ECB;

                ICryptoTransform dec = aesAlg.CreateDecryptor(aesAlg.Key
                    , aesAlg.IV);
                dec.TransformBlock(tmp, 0, (int)sizePadded, decrypted, 0);

                decrypted = new byte[size];
                Array.Copy(tmp, decrypted, size);
            }

            return decrypted;
        }
    }
}