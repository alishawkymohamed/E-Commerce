using IHelperServices;

namespace HelperServices
{
    public class SmsServices : _HelperService, ISmsServices
    {
        public SmsServices()
        {
        }

        public void Send(string sender, string[] to, string body)
        {
            //throw new NotImplementedException();
        }
    }
}