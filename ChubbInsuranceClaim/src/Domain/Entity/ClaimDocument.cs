using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimDocument : AuditableEntity
    {
        public int ClaimId { get; set; }
        public InsuranceClaim Claim { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
