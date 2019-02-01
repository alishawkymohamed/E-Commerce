using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Product : _BaseEntity, IAuditableInsert, IAuditableDelete, IAuditableUpdate
    {
        public Product()
        {
            Specifications = new HashSet<Specification>();
            Photos = new HashSet<Photo>();
        }
        public long ProductId { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }

        [NotMapped]
        public string ProductName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(ProductNameAr) ? ProductNameEn : ProductNameAr) :
                    (string.IsNullOrEmpty(ProductNameEn) ? ProductNameAr : ProductNameEn);
            private set { }
        }

        public string Code { get; set; }

        public decimal Price { get; set; }
        public decimal Deduction { get; set; }

        [NotMapped]
        public decimal PriceAfterDeduction
        {
            get
            {
                return Deduction <= 0 ? Price : Price - (Price * (Deduction / 100));
            }
            private set { }
        }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }


        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<Specification> Specifications { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

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
