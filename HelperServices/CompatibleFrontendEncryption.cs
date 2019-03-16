using IHelperServices;
using Microsoft.Extensions.Options;
using Models.DTOs;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HelperServices
{
    public class CompatibleFrontendEncryption : _HelperService, ICompatibleFrontendEncryption
    {
        private readonly AppSettings _AppSettings;

        private RijndaelManaged Rijndael;
        private int Iterations;
        private byte[] Salt;
        private string SecretPassword;

        public CompatibleFrontendEncryption(IOptions<AppSettings> appSettings)
        {
            Rijndael = new RijndaelManaged();
            _AppSettings = appSettings.Value;
            Rijndael.BlockSize = _AppSettings.EncryptionSettings.BlockSize;
            Rijndael.KeySize = _AppSettings.EncryptionSettings.KeySize;
            Rijndael.IV = HexStringToByteArray(_AppSettings.EncryptionSettings.IV);

            Rijndael.Padding = PaddingMode.PKCS7;
            Rijndael.Mode = CipherMode.CBC;
            Iterations = _AppSettings.EncryptionSettings.Iterations;
            Salt = Encoding.UTF8.GetBytes(_AppSettings.EncryptionSettings.Salt);
            SecretPassword = _AppSettings.EncryptionSettings.SecretPassword;
            Rijndael.Key = GenerateKey(SecretPassword);
        }

        public string Encrypt(string strPlainText)
        {
            byte[] strText = new UTF8Encoding().GetBytes(strPlainText);
            ICryptoTransform transform = Rijndael.CreateEncryptor();
            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);

            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            ICryptoTransform decryptor = Rijndael.CreateDecryptor(Rijndael.Key, Rijndael.IV);
            byte[] originalBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(originalBytes);
        }

        private byte[] HexStringToByteArray(string strHex)
        {
            dynamic r = new byte[strHex.Length / 2];
            for (int i = 0; i <= strHex.Length - 1; i += 2)
            {
                r[i / 2] = Convert.ToByte(Convert.ToInt32(strHex.Substring(i, 2), 16));
            }
            return r;
        }

        private byte[] GenerateKey(string strPassword)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(strPassword), Salt, Iterations);

            return rfc2898.GetBytes(128 / 8);
        }
    }
}
