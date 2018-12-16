using System;

namespace Models.Interfaces
{
    public interface IAuditableDelete
    {
        int? DeletedBy { get; set; }
        DateTimeOffset? DeletedOn { get; set; }
    }
}