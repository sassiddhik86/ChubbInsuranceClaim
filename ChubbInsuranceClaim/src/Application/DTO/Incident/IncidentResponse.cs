using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Application.DTO.Incident
{
    public class IncidentResponse
    {
        public int Id { get; set; }
        public IncidentType IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
