using AutoMapper;
using HelperServices;
using IBusinessServices.IAuthenticationServices;
using IHelperServices;
using IRepositories;
using IRepositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessServices.AuthenticationServices
{
    public class RolesService : _BusinessService<Role, RoleDTO, RoleDTO>, IRolesService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISessionServices _sessionServices;
        //private readonly ISignalRServices _signalRServices;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IRoleRepository _roles;
        private readonly IUserRepository _users;

        public RolesService(IUnitOfWork uow, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices/*, ISignalRServices signalRServices*/) : base(uow, mapper, stringLocalizer, sessionServices)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _sessionServices = sessionServices;
            _sessionServices.CheckArgumentIsNull(nameof(_sessionServices));

            //_signalRServices = signalRServices;
            //_signalRServices.CheckArgumentIsNull(nameof(_signalRServices));

            _stringLocalizer = stringLocalizer;
            _stringLocalizer.CheckArgumentIsNull(nameof(_stringLocalizer));

            _roles = _uow.Repository<Role>() as IRoleRepository;
            _roles.CheckArgumentIsNull(nameof(_roles));

            _users = _uow.Repository<User>() as IUserRepository;
            _users.CheckArgumentIsNull(nameof(_users));
        }

        public Task<List<Role>> FindUserRolesAsync(int userId)
        {
            IQueryable<Models.DbModels.Role> userRolesQuery = from role in _roles.GetAll()
                                                              from userRoles in role.UserRoles
                                                              where userRoles.UserId == userId
                                                              select role;

            return userRolesQuery.OrderBy(x => x.RoleName).ToListAsync();
        }

        public async Task<bool> IsUserInRole(int userId, string roleName)
        {
            IQueryable<Role> userRolesQuery = from role in _roles.GetAll()
                                              where role.RoleName == roleName
                                              from user in role.UserRoles
                                              where user.UserId == userId
                                              select role;
            Models.DbModels.Role userRole = await userRolesQuery.FirstOrDefaultAsync();
            return userRole != null;
        }

        public Task<List<User>> FindUsersInRoleAsync(string roleName)
        {
            IQueryable<int> roleUserIdsQuery = from role in _roles.GetAll()
                                               where role.RoleName == roleName
                                               from user in role.UserRoles
                                               select user.UserId;
            return _users.GetAll(user => roleUserIdsQuery.Contains(user.UserId))
                         .ToListAsync();
        }
    }
}
