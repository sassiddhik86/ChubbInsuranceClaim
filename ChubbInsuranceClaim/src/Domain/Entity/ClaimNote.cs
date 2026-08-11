using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimNote : AuditableEntity
    {
        public Guid ClaimId { get; set; }

        public InsuranceClaim Claim { get; set; } = null!;

        public string Notes { get; set; } = string.Empty;

        public bool InternalOnly { get; set; }

        public Guid CreatedByUserId { get; set; }

        public BusinessUser CreatedByUser { get; set; } = null!;
    }
}
