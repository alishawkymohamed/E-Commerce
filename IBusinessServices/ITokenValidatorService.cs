using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IBusinessServices
{
    public interface ITokenValidatorService : _IBusinessService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}
