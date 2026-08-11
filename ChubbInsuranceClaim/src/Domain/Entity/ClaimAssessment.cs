using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimAssessment : AuditableEntity
    {
        public Guid ClaimId { get; set; }

        public Guid AssessorUserId { get; set; }

        public decimal EstimatedDamageAmount { get; set; }

        public decimal RecommendedSettlementAmount { get; set; }

        public bool FraudDetected { get; set; }

        public string Findings { get; set; } = string.Empty;

        public virtual InsuranceClaim Claim { get; set; } = null!;
    }
}
