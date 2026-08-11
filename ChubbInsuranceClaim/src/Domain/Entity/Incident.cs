using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class Incident : AuditableEntity
    {
        public IncidentType IncidentType { get; set; }

        public DateTime IncidentDate { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? PoliceReportNumber { get; set; }

        //public int CreatedByUserId { get; set; }

        //public InsuranceClaim CreatedByUser { get; set; } = null!;

        public ICollection<InsuranceClaim> Claims { get; set; } = new List<InsuranceClaim>();
    }
}
