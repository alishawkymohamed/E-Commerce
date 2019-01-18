namespace Models.DbModels
{
    public class Address : _BaseEntity
    {
        public int AddressId { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
    }
}
