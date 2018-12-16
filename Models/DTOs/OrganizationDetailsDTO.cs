namespace Models.DTOs
{
    public class OrganizationDetailsDTO
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationNameAr { get; set; }
        public string OrganizationNameEn { get; set; }
        public int? ParentOrganizationId { get; set; }
        public int? RootOrganizationId { get; set; }
        public int? AdminOrganizationId { get; set; }
        public bool IsAdminOrganization { get; set; }
        public bool IsCategory { get; set; }
        public bool IsOuterOrganization { get; set; }
        public bool IsMainOrganization { get; set; }
        public bool DelegateOnlyToSiblingsAndChildren { get; set; }
        public bool SMSAllowed { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public int? DisplayOrder { get; set; }
        public int Code { get; set; }
        public int? ManagerUserId { get; set; }
        public byte[] StampFile { get; set; }
        public string Color { get; set; }
        public string FullPathAr { get; set; }
        public string FullPathEn { get; set; }
        public string FullPath { get; set; }
        public string ArchFolderEntryId { get; set; }
        public bool IsActive { get; set; }
    }
}
