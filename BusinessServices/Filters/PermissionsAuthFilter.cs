//using IBusinessServices;
//using IHelperServices;
//using IRepositories;
//using Microsoft.AspNetCore.Authorization;
//using System.Linq;
//using System.Threading.Tasks;

//public class AuthHandler : AuthorizationHandler<HasPermissionRequirment>
//{
//    private readonly ISessionServices _sessionService;
//    private readonly IUsersService _userService;
//    private readonly IUnitOfWork _unitOfWork;

//    public AuthHandler(ISessionServices sessionService, IUsersService usersService, IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//        _sessionService = sessionService;
//        _userService = usersService;
//    }

//    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirment requirement)
//    {
//        if (!_sessionService.HttpContext.User.Identity.IsAuthenticated)
//        {
//            context.Fail();
//            return Task.CompletedTask;
//        }
//        string RequestURL = _sessionService.HttpContext.Request.Path.Value.ToUpper().Split('?')[0];
//        string RequestMethod = _sessionService.HttpContext.Request.Method.ToUpper();
//        if (RequestURL.StartsWith("/api/file/download".ToUpper()) && RequestMethod == "GET")
//        {
//            context.Succeed(requirement);
//            return Task.CompletedTask;
//        }
//        string PermissionCodeOfRequest = _unitOfWork.Repository<Permission>().GetAllAsync(x => x.URL.ToUpper().Contains(RequestURL) && x.Method.ToUpper().Contains(RequestMethod), false).Result
//            .FirstOrDefault()?.PermissionCode.ToUpper();

//        int CurrentLoggedInUserId = _sessionService.UserId.GetValueOrDefault();
//        int CurrentLoggedInRoleId = _sessionService.RoleId.GetValueOrDefault();
//        int CurrentLoggedInOrganizationId = _sessionService.OrganizationId.GetValueOrDefault();
//        string CurrentLoggedInUsername = _sessionService.UserName;
//        var AuthTicket = _sessionService.GetAuthTicket(CurrentLoggedInUsername);

//        if (PermissionCodeOfRequest != null && CurrentLoggedInUserId != 0 && CurrentLoggedInRoleId != 0 && CurrentLoggedInOrganizationId != 0)
//        {
//            if (AuthTicket == null)
//            {
//                AuthTicket = _userService.GetAuthDTO(CurrentLoggedInUsername, CurrentLoggedInOrganizationId, CurrentLoggedInRoleId);
//                _sessionService.SetAuthTicket(CurrentLoggedInUsername, AuthTicket);
//                #region Old Manual Check
//                //var UserRole = dbContext.AuthUserRoles
//                //    .Include(x => x.User)
//                //    .ThenInclude(x => x.UserPermissions)
//                //    .ThenInclude(x => x.Permission)
//                //    .Include(x => x.Role)
//                //    .ThenInclude(x => x.RolePermissions)
//                //    .ThenInclude(x => x.Permission)
//                //     .Where(x => !x.EnabledUntil.HasValue || x.EnabledUntil.Value > DateTimeOffset.Now)
//                //        .Where(x => !x.EnabledSince.HasValue || x.EnabledSince.Value < DateTimeOffset.Now)
//                //        .AsNoTracking()
//                //    .SingleOrDefault(x => x.RoleId == CurrentLoggedInRoleId && x.UserId == CurrentLoggedInUserId && x.OrganizationId == CurrentLoggedInOrganizationId);

//                //if (UserRole.RoleOverridesUserPermissions == true)
//                //{
//                //    if (UserRole.Role.RolePermissions.Where(x => x.Enabled == true)
//                //        .Select(x => x.Permission.PermissionCode.ToUpper()).Contains(PermissionCodeOfRequest))
//                //    {
//                //        context.Succeed(requirement);
//                //        return Task.CompletedTask;
//                //    }
//                //    context.Fail();
//                //    return Task.CompletedTask;
//                //}
//                //else
//                //{
//                //    if (UserRole.Role.RolePermissions.Where(x => x.Enabled == true)
//                //        .Select(x => x.Permission.PermissionCode.ToUpper()).Contains(PermissionCodeOfRequest) ||
//                //        UserRole.User.UserPermissions.Where(x => x.Enabled == true)
//                //        .Select(x => x.Permission.PermissionCode.ToUpper()).Contains(PermissionCodeOfRequest))
//                //    {
//                //        context.Succeed(requirement);
//                //        return Task.CompletedTask;
//                //    }
//                //    context.Fail();
//                //    return Task.CompletedTask;
//                //}
//                #endregion
//            }
//            if (_sessionService.GetAuthTicket(CurrentLoggedInUsername).Permissions.Contains(PermissionCodeOfRequest.ToUpper()))
//            {
//                context.Succeed(requirement);
//                return Task.CompletedTask;
//            }
//            else
//            {
//                context.Fail();
//                return Task.CompletedTask;
//            }
//        }
//        else
//        {
//            context.Fail();
//            return Task.CompletedTask;
//        }
//    }
//}
//public class HasPermissionRequirment : IAuthorizationRequirement
//{

//}