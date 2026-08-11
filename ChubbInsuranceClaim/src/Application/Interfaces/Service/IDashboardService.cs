using ChubbInsuranceClaim.src.Application.DTO.Dashboard;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IDashboardService
    {
        Task<DashboardResponse> GetCustomerDashboardAsync(
               int customerId);


        Task<DashboardResponse> GetOfficerDashboardAsync(
            int officerId);


        Task<DashboardResponse> GetSupervisorDashboardAsync();
    }
}
