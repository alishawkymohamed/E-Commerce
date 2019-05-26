using Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbModels
{
    public class Photo : _BaseEntity, IAuditableDelete
    {
        public long PhotoId { get; set; }
        public string UniqueName { get; set; }
        public string Base64String { get; set; }
        public string Path { get; set; }
        public bool? IsMainPhoto { get; set; }
        public bool? IsRealPhoto { get; set; }
        public bool? IsCommercialPhoto { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public virtual Product Product { get; set; }

        #region IAuditableDelete
        public int? DeletedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
        #endregion
    }
}
