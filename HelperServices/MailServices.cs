using IHelperServices;

namespace HelperServices
{
    public class MailServices : _HelperService, IMailServices
    {
        public MailServices()
        {
        }

        public void Send(string sender, string[] to, string[] cc, string[] bcc, string title, string body)
        {
            //throw new NotImplementedException();
        }
    }
}