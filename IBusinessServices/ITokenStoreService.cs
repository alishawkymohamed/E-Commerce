using Models.DbModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IBusinessServices.IAuthenticationServices
{
    public interface ITokenStoreService : _IBusinessService
    {
        void AddUserToken(UserToken userToken);
        void AddUserToken(User user, string refreshToken, string accessToken, string refreshTokenSource);
        Task<bool> IsValidTokenAsync(string accessToken, int userId);
        void DeleteExpiredTokensAsync();
        Task<UserToken> FindTokenAsync(string refreshToken);
        Task DeleteTokenAsync(string refreshToken);
        void DeleteTokensWithSameRefreshTokenSource(string refreshTokenIdHashSource);
        void InvalidateUserTokens(int userId);
        Task<(string accessToken, string refreshToken, IEnumerable<Claim> Claims)> CreateJwtTokens(User user, string refreshTokenSource);
        void RevokeUserBearerTokens(string userIdValue, string refreshToken);
    }
}
