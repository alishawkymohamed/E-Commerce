using System.Globalization;

namespace Models.DTOs
{
    public class SpecificationDTO
    {
        public int SpecificationId { get; set; }
        public string SpecificationNameAr { get; set; }
        public string SpecificationNameEn { get; set; }
        public string SpecificationName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(SpecificationNameAr) ? SpecificationNameEn : SpecificationNameAr) :
                    (string.IsNullOrEmpty(SpecificationNameEn) ? SpecificationNameAr : SpecificationNameEn);
            private set { }
        }
        public string SpecificationValueAr { get; set; }
        public string SpecificationValueEn { get; set; }
        public string SpecificationValue
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(SpecificationValueAr) ? SpecificationValueEn : SpecificationValueAr) :
                    (string.IsNullOrEmpty(SpecificationValueEn) ? SpecificationValueAr : SpecificationValueEn);
            private set { }
        }
        public long? ProductId { get; set; }
    }
}