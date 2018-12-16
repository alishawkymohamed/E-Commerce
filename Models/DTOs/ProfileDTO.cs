using System.Collections.Generic;

namespace Models.DTOs
{
    public class ProfileDTO
    {
        public string UserName { get; set; }
        public string FullNameEn { get; set; }
        public string FullNameAr { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public int? ProfileImageFileId { get; set; }
        public int? SignatureFileId { get; set; }
        public int? TrkeenFileId { get; set; }
        public int? StampFileId { get; set; }
        public virtual IEnumerable<UserRoleDTO> UserRoles { get; set; }
    }
}
