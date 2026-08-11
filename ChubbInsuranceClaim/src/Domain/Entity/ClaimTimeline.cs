using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimTimeline : AuditableEntity
    {
        public Guid ClaimId { get; set; }

        public InsuranceClaim Claim { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Guid ActionById { get; set; }

        public BusinessUser ActionBy { get; set; } = null!;
    }
}
