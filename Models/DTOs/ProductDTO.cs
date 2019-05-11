using System.Collections.Generic;
using System.Globalization;

namespace Models.DTOs
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
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
        public bool IsApproved { get; set; }
        public decimal PriceAfterDeduction
        {
            get
            {
                return Deduction <= 0 ? Price : Price - (Price * (Deduction / 100));
            }
            private set { }
        }

        public int? UserId { get; set; }
        public int SubCategoryId { get; set; }
        public virtual List<SpecificationDTO> Specifications { get; set; }
        public virtual List<PhotoDTO> Photos { get; set; }
    }
}
