using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class Department : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Team> Teams { get; set; }
            = new List<Team>();
    }
}
