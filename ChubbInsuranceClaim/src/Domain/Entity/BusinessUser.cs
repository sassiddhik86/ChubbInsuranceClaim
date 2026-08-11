using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;
using System.Data;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class BusinessUser : AuditableEntity
    {
        public string EmployeeNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public BusinessRole Role { get; set; } = null!;

        // Customer Claims
        public ICollection<InsuranceClaim> Claims { get; set; } = new List<InsuranceClaim>();

        // Officer Assignments
        public ICollection<ClaimAssignment> AssignedClaims { get; set; } = new List<ClaimAssignment>();
    }
}
