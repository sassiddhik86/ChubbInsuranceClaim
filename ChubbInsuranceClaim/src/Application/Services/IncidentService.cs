using ChubbInsuranceClaim.src.Application.DTO.Incident;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncidentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IncidentResponse> CreateIncidentAsync(int userId, CreateIncidentRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null) { throw new Exception("User not found."); }

            var incident =
                new Incident
                {
                    IncidentType = request.IncidentType,
                    IncidentDate = request.IncidentDate,
                    Location = request.Location,
                    Description = request.Description,
                    PoliceReportNumber = request.PoliceReportNumber,
                    CreatedDate = DateTime.UtcNow
                };

            await _unitOfWork.Incidents.AddAsync(incident);
            await _unitOfWork.SaveChangesAsync();

            return MapResponse(incident);
        }

        public async Task UpdateIncidentAsync(int incidentId, UpdateIncidentRequest request)
        {
            var incident = await _unitOfWork.Incidents.GetByIdAsync(incidentId);

            if (incident == null) { throw new Exception("Incident not found."); }

            incident.IncidentType = request.IncidentType;
            incident.Location = request.Location;
            incident.Description = request.Description;
            incident.PoliceReportNumber = request.PoliceReportNumber;
            incident.UpdatedDate = DateTime.UtcNow;

            _unitOfWork.Incidents.Update(incident);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IncidentResponse> GetByIdAsync(int incidentId)
        {
            var incident = await _unitOfWork.Incidents.GetByIdAsync(incidentId);

            if (incident == null) { throw new Exception("Incident not found."); }

            return MapResponse(incident);
        }

        public async Task<List<IncidentResponse>> GetMyIncidentsAsync(int userId)
        {
            var incidents = await _unitOfWork.Incidents.GetAllAsync();

            return incidents.Select(MapResponse).ToList();
        }

        private static IncidentResponse MapResponse(Incident incident)
        {
            return new IncidentResponse
            {
                Id = incident.Id,
                IncidentType = incident.IncidentType,
                IncidentDate = incident.IncidentDate,
                Location = incident.Location,
                Description = incident.Description
            };
        }
    }
}