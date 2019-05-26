namespace Models.DTOs
{
    public class PhotoDTO
    {
        public long PhotoId { get; set; }
        public string Base64String { get; set; }
        public string Path { get; set; }
        public bool? IsMainPhoto { get; set; }
        public bool? IsRealPhoto { get; set; }
        public bool? IsCommercialPhoto { get; set; }
        public long? ProductId { get; set; }
    }
}