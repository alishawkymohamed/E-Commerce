using System;

namespace Models
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string UserName { get; set; }
        public string FullNameEn { get; set; }
        public string FullNameAr { get; set; }
        public bool Enabled { get; set; }
        public DateTimeOffset? EnabledUntil { get; set; }
        public byte[] ProfileImage { get; set; }
        public int? SignatureFileId { get; set; }
        public int? TrkeenFileId { get; set; }
        public int? StampFileId { get; set; }
        public string EmployeeNumber { get; set; }
        public string SSN { get; set; }
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        public string IqamaNumber { get; set; }
        public int? GenderId { get; set; }
        public string GenderName { get; set; }
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
        public int? JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public int? WorkPlaceId { get; set; }
        public string WorkPlaceName { get; set; }
        public string Address { get; set; }
        public string DefaultCulture { get; set; }
        public string DefaultCalendar { get; set; }
        public string WorkPhoneNumber { get; set; }
        public bool NotificationByMail { get; set; }
        public bool NotificationBySMS { get; set; }
        public bool IsIndividual { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsCorrespondentForAllOrganizations { get; set; }
    }
}