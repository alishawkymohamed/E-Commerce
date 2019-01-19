using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Category : _BaseEntity, IAuditableInsert, IAuditableDelete, IAuditableUpdate
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryNameEn { get; set; }

        [NotMapped]
        public string CategoryName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
              (string.IsNullOrEmpty(CategoryNameAr) ? CategoryNameEn : CategoryNameAr) :
              (string.IsNullOrEmpty(CategoryNameEn) ? CategoryNameAr : CategoryNameEn);
            private set { }
        }

        public ICollection<Product> Products { get; set; }

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
