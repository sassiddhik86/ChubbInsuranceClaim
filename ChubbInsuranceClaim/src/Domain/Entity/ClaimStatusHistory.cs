using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimStatusHistory : AuditableEntity
    {
        public int ClaimId { get; set; }

        public InsuranceClaim Claim { get; set; } = null!;

        public ClaimStatus Status { get; set; }

        public string Remarks { get; set; } = string.Empty;
    }
}
