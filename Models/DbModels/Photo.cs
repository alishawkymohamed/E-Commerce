using Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Photo : _BaseEntity, IAuditableDelete
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

        public bool? IsMainPhoto { get; set; }
        public bool? IsRealPhoto { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public Product Product { get; set; }

        #region IAuditableDelete
        public int? DeletedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
        #endregion
    }
}
