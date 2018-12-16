namespace Models
{
    public class UserSummaryDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Enabled { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}