using IBusinessServices;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessServices.AuthenticationServices
{
    public class SecurityService : ISecurityService
    {
        public string GetSha256Hash(string input)
        {
            using (SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                byte[] byteValue = Encoding.UTF8.GetBytes(input);
                byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }
    }
}