using System;

namespace Models.Interfaces
{
    public interface IAuditableUpdate
    {
        int? UpdatedBy { get; set; }
        DateTimeOffset? UpdatedOn { get; set; }
    }
}