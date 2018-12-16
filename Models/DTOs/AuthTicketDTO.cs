using System.Collections.Generic;

namespace Models.DTOs
{
    public class AuthTicketDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int? ProfileImageFileId { get; set; }
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string DefaultCulture { get; set; }
        public string DefaultCalendar { get; set; }
        public virtual IEnumerable<string> Permissions { get; set; }
        public virtual IEnumerable<UserRoleDTO> UserRoles { get; set; }
    }
}
