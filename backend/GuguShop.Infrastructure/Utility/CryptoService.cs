﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GuguShop.Infrastructure.Utility;

public class CryptoService: ICryptoService
{
        //https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
        
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 128;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;
        private const string AlgorithmName = "AesManaged";
        public string Encrypt(string plainText, string passPhrase)
        {
            if (string.IsNullOrEmpty(plainText.Trim()))
            {
                throw new InvalidDataException("Plain text is null or empty!");
            }
            if (string.IsNullOrEmpty(passPhrase.Trim()))
            {
                throw new InvalidDataException("Pass phrase is null or empty!");
            }
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate128BitsOfRandomEntropy();
            var ivStringBytes = Generate128BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations);
            var keyBytes = password.GetBytes(Keysize / 8);
            using var symmetricKey = Aes.Create(AlgorithmName);
            if (symmetricKey == null)
            {
                throw new InvalidOperationException("Can not create AesManaged symmetric algorithm");
            }
            symmetricKey.BlockSize = Keysize;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            using var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
            var cipherTextBytes = saltStringBytes;
            cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
            cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string encryptText, string passPhrase)
        {
            if (string.IsNullOrEmpty(encryptText.Trim()))
            {
                throw new InvalidDataException("Encrypt text is null or empty!");
            }
            if (string.IsNullOrEmpty(passPhrase.Trim()))
            {
                throw new InvalidDataException("Pass phrase is null or empty!");
            }
            // Get the complete stream of bytes that represent:
            // [16 bytes of Salt] + [16 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(encryptText);
            // Get the saltbytes by extracting the first 16 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 16 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 32 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations);
            var keyBytes = password.GetBytes(Keysize / 8);
            using var symmetricKey = Aes.Create(AlgorithmName);
            if (symmetricKey == null)
            {
                throw new InvalidOperationException("Can not create AesManaged symmetric algorithm");
            }
            symmetricKey.BlockSize = Keysize;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            using var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes);
            using var memoryStream = new MemoryStream(cipherTextBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        private static byte[] Generate128BitsOfRandomEntropy()
        {
            var randomBytes = new byte[Keysize / 8]; // 16 Bytes will give us 128 bits.
            using var rngCsp = RandomNumberGenerator.Create();
            // Fill the array with cryptographically secure random bytes.
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }
}