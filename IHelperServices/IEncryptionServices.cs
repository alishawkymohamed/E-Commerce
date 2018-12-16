namespace IHelperServices
{
    public interface IEncryptionServices : _IHelperService
    {
        string EncryptString(string plain_text, string password, string salt = null);

        string DecryptString(string encrypted_value, string password, string salt = null);
    }
}