namespace IHelperServices
{
    public interface ISmsServices : _IHelperService
    {
        void Send(string sender, string[] to, string body);
    }
}