using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class ClaimAssignment : AuditableEntity
    {
        public int ClaimId { get; set; }
        public InsuranceClaim Claim { get; set; } = null!;
        public int OfficerId { get; set; }
        public BusinessUser Officer { get; set; } = null!;
        public DateTime AssignedDate { get; set; }
    }
}
