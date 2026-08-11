using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Application.DTO.Incident
{
    public class UpdateIncidentRequest
    {
        public IncidentType IncidentType { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? PoliceReportNumber { get; set; }
    }
}
