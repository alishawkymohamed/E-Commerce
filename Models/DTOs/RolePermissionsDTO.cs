using System.Collections.Generic;

namespace Models.DTOs
{
    public class RolePermissionsDTO
    {
        public int RoleId { get; set; }
        public IEnumerable<PermissionCategoryDTO> PermissionCategories { get; set; }
    }

    public class RolePermissionDTO
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool? PermissionStatus { get; set; }
    }

    public class PermissionCategoryDTO
    {
        public string PermissionCategoryName { get; set; }
        public IEnumerable<RolePermissionDTO> Permissions { get; set; }
    }
}
