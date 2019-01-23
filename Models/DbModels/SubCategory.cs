using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class SubCategory : _BaseEntity, IAuditableInsert, IAuditableDelete, IAuditableUpdate
    {
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }
        public int SubCategoryId { get; set; }
        public string SubCategoryNameAr { get; set; }
        public string SubCategoryNameEn { get; set; }

        [NotMapped]
        public string SubCategoryName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
              (string.IsNullOrEmpty(SubCategoryNameAr) ? SubCategoryNameEn : SubCategoryNameAr) :
              (string.IsNullOrEmpty(SubCategoryNameEn) ? SubCategoryNameAr : SubCategoryNameEn);
            private set { }
        }

        public string Code { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }


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
