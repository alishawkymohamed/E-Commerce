namespace IBusinessServices
{
    public interface ISecurityService : _IBusinessService
    {
        string GetSha256Hash(string input);
    }
}
