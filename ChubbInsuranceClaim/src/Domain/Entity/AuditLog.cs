using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class AuditLog : AuditableEntity
    {
        public string TableName { get; set; } = string.Empty;

        public string RecordId { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;

        public string? OldValues { get; set; }

        public string? NewValues { get; set; }

        public Guid PerformedById { get; set; }

        public BusinessUser PerformedBy { get; set; } = null!;
    }
}
