using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class InsuranceClaim : AuditableEntity
    {
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public ClaimStatus Status { get; set; }
        public int UserId { get; set; }
        public BusinessUser User { get; set; } = null!;
        public int IncidentId { get; set; }
        public Incident Incident { get; set; } = null!;
        public ICollection<ClaimDocument> Documents { get; set; } = new List<ClaimDocument>();
        public ICollection<ClaimStatusHistory> StatusHistories { get; set; } = new List<ClaimStatusHistory>();
        public ICollection<ClaimAssignment> Assignments { get; set; } = new List<ClaimAssignment>();
    }
}
