using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Models.DTOs
{
    public class PhotoDTO
    {
        public long PhotoId { get; set; }
        public string PhotoNameAr { get; set; }
        public string PhotoNameEn { get; set; }
        public string PhotoName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(PhotoNameAr) ? PhotoNameEn : PhotoNameAr) :
                    (string.IsNullOrEmpty(PhotoNameEn) ? PhotoNameAr : PhotoNameEn);
            private set { }
        }

        public IFormFile File { get; set; }
        public string Path { get; set; }
        public bool? IsMainPhoto { get; set; }
        public bool? IsRealPhoto { get; set; }
        public bool? IsCommercialPhoto { get; set; }
        public long? ProductId { get; set; }
    }
}