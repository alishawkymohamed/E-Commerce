namespace IHelperServices
{
    public interface IMailServices : _IHelperService
    {
        void Send(string sender, string[] to, string[] cc, string[] bcc, string title, string body);
    }
}