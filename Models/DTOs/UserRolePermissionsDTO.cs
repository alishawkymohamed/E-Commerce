using System.Collections.Generic;

namespace Models.DTOs
{
    public class UserRolePermissionsDTO
    {
        public int UserId { get; set; }
        public IEnumerable<UserRoles> UserRoles { get; set; }
    }

    public class UserRoles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public bool RoleOverridesUserPermissions { get; set; }
        public IEnumerable<PermissionCategories> PermissionCategories { get; set; }
    }
    public class PermissionCategories
    {
        public string PermissionCategoryName { get; set; }
        public IEnumerable<UserRolePermission> UserRolePermissions { get; set; }
    }

    public class UserRolePermission
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool? RolePermissionEnabled { get; set; }
        public bool? UserPermissionEnabled { get; set; }
    }
}

