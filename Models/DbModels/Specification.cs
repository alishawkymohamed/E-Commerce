using Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Specification : _BaseEntity, IAuditableInsert, IAuditableDelete, IAuditableUpdate
    {
        public int SpecificationId { get; set; }
        public string SpecificationNameAr { get; set; }
        public string SpecificationNameEn { get; set; }

        [NotMapped]
        public string SpecificationName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(SpecificationNameAr) ? SpecificationNameEn : SpecificationNameAr) :
                    (string.IsNullOrEmpty(SpecificationNameEn) ? SpecificationNameAr : SpecificationNameEn);
            private set { }
        }
        public string SpecificationValueAr { get; set; }
        public string SpecificationValueEn { get; set; }

        [NotMapped]
        public string SpecificationValue
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(SpecificationValueAr) ? SpecificationValueEn : SpecificationValueAr) :
                    (string.IsNullOrEmpty(SpecificationValueEn) ? SpecificationValueAr : SpecificationValueEn);
            private set { }
        }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public Product Product { get; set; }

        #region IAuditableInsert
        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
        #endregion

        #region IAuditableDelete
        public int? DeletedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
        #endregion

        #region IAuditableUpdate
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual User UpdatedByUser { get; set; }
        #endregion
    }
}
