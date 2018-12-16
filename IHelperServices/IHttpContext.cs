using Microsoft.AspNetCore.Http;

namespace IHelperServices
{
    public interface IHttpContext
    {
        HttpContext HttpContext { get; set; }
    }
}
