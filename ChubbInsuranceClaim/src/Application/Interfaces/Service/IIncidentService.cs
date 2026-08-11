using ChubbInsuranceClaim.src.Application.Common.Models;
using ChubbInsuranceClaim.src.Application.DTO.Incident;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IIncidentService
    {
        Task<IncidentResponse> CreateIncidentAsync(int userId, CreateIncidentRequest request);
        Task UpdateIncidentAsync(int incidentId, UpdateIncidentRequest request);
        Task<IncidentResponse> GetByIdAsync(int incidentId);
        Task<List<IncidentResponse>> GetMyIncidentsAsync(int userId);
    }
}
