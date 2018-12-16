namespace Models.DTOs
{
    public class OrgTreeDTO
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Color { get; set; }
        public bool HasChilds { get; set; }
    }
}
