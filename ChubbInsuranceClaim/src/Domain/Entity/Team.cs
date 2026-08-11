using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class Team : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

        public ICollection<BusinessUser> Users { get; set; }
            = new List<BusinessUser>();
    }
}
