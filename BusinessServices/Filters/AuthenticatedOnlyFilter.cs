using IHelperServices;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

public class AuthenticatedOnlyFilter : AuthorizationHandler<AuthenticatedOnlyRequirment>
{
    private readonly ISessionServices sessionServices;

    public AuthenticatedOnlyFilter(ISessionServices _sessionServices)
    {
        sessionServices = _sessionServices;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthenticatedOnlyRequirment requirement)
    {
        if (sessionServices.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        context.Fail();
        return Task.CompletedTask;
    }
}

public class AuthenticatedOnlyRequirment : IAuthorizationRequirement
{

}