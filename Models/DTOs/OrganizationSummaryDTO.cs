namespace Models.DTOs
{
    public class OrganizationSummaryDTO
    {
        public int OrganizationId { get; set; }
        public string OrganizationNameAr { get; set; }
        public string OrganizationNameEn { get; set; }
        public bool IsAdminOrganization { get; set; }
        public bool IsOuterOrganization { get; set; }
        public bool IsActive { get; set; }
        public int Code { get; set; }
    }
}
