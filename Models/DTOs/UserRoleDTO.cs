using System;

namespace Models.DTOs
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset? EnabledSince { get; set; }
        public DateTimeOffset? EnabledUntil { get; set; }
        public string Notes { get; set; }
    }
}
