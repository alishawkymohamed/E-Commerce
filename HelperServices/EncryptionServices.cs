using IHelperServices;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HelperServices
{
    public class EncryptionServices : _HelperService, IEncryptionServices
    {
        public string EncryptString(string plain_text, string password, string salt = null)
        {
            password = EnsureValidPassword(password);
            salt = salt ?? password;
            salt = EnsureValidPassword(salt);
            //
            string encrypted;

            using (Aes aes = Aes.Create())
            {
                Tuple<byte[], byte[]> keys = GetAesKeyAndIV(password, salt, aes);
                aes.Key = keys.Item1;
                aes.IV = keys.Item2;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memory_stream = new MemoryStream())
                {
                    using (CryptoStream crypto_stream = new CryptoStream(memory_stream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(crypto_stream))
                        {
                            writer.Write(plain_text);
                        }

                        byte[] encrypted_bytes = memory_stream.ToArray();
                        encrypted = ToString(encrypted_bytes);
                    }
                }
            }

            return encrypted;
        }

        public string DecryptString(string encrypted_value, string password, string salt = null)
        {
            password = EnsureValidPassword(password);
            salt = salt ?? password;
            salt = EnsureValidPassword(salt);
            //
            string decrypted;

            using (Aes aes = Aes.Create())
            {
                Tuple<byte[], byte[]> keys = GetAesKeyAndIV(password, salt, aes);
                aes.Key = keys.Item1;
                aes.IV = keys.Item2;

                // create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // create the streams used for encryption.
                byte[] encrypted_bytes = ToByteArray(encrypted_value);
                using (MemoryStream memory_stream = new MemoryStream(encrypted_bytes))
                {
                    using (CryptoStream crypto_stream = new CryptoStream(memory_stream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(crypto_stream))
                        {
                            decrypted = reader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }

        private static byte[] ToByteArray(string input)
        {
            return Convert.FromBase64String(input);
        }

        private static string ToString(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        private static Tuple<byte[], byte[]> GetAesKeyAndIV(string password, string salt, SymmetricAlgorithm symmetricAlgorithm)
        {
            const int bits = 8;
            byte[] key = new byte[16];
            byte[] iv = new byte[16];

            Rfc2898DeriveBytes derive_bytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt));
            key = derive_bytes.GetBytes(symmetricAlgorithm.KeySize / bits);
            iv = derive_bytes.GetBytes(symmetricAlgorithm.BlockSize / bits);

            return new Tuple<byte[], byte[]>(key, iv);
        }

        private static string EnsureValidPassword(string str)
        {
            while (str.Length < 32)
                str += str;
            str = str.Substring(0, 32);
            return str;
        }
    }
}