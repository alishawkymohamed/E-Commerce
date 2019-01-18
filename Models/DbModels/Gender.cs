using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Gender : _BaseEntity
    {
        public int GenderId { get; set; }
        public string GenderNameAr { get; set; }
        public string GenderNameEn { get; set; }

        [NotMapped]
        public string GenderName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
              (string.IsNullOrEmpty(GenderNameAr) ? GenderNameEn : GenderNameAr) :
              (string.IsNullOrEmpty(GenderNameEn) ? GenderNameAr : GenderNameEn);
            private set { }
        }
    }
}
