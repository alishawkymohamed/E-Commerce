namespace IHelperServices
{
    public interface ICompatibleFrontendEncryption : _IHelperService
    {
        string Encrypt(string strPlainText);
        string Decrypt(string encryptedText);
    }
}
