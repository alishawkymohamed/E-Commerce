using System;

namespace Models.Interfaces
{
    public interface IAuditableInsert
    {
        int? CreatedBy { get; set; }
        DateTimeOffset? CreatedOn { get; set; }
    }
}