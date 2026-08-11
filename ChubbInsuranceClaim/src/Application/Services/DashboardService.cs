using ChubbInsuranceClaim.src.Application.DTO.Dashboard;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Domain.Enums;
using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DashboardResponse> GetCustomerDashboardAsync(
            int customerId)
        {

            var claims =
                await _unitOfWork.Claims
                .GetClaimsByCustomerAsync(customerId);


            return BuildDashboard(claims);
        }

        public async Task<DashboardResponse> GetOfficerDashboardAsync(
            int officerId)
        {

            var claims =
                await _unitOfWork.Claims
                .GetAssignedClaimsAsync(officerId);

            return BuildDashboard(claims);
        }

        public async Task<DashboardResponse> GetSupervisorDashboardAsync()
        {

            var claims =
                await _unitOfWork.Claims
                .GetAllAsync();

            return BuildDashboard(claims);
        }

        private static DashboardResponse BuildDashboard(
            List<InsuranceClaim> claims)
        {

            return new DashboardResponse
            {
                TotalClaims =
                    claims.Count,


                PendingClaims =
                    claims.Count(x =>
                        x.Status == ClaimStatus.Submitted ||
                        x.Status == ClaimStatus.Assigned ||
                        x.Status == ClaimStatus.UnderReview ||
                        x.Status == ClaimStatus.NeedMoreInformation),

                ApprovedClaims =
                    claims.Count(x =>
                        x.Status == ClaimStatus.Approved),



                RejectedClaims =
                    claims.Count(x =>
                        x.Status == ClaimStatus.Rejected),



                SettledClaims =
                    claims.Count(x =>
                        x.Status == ClaimStatus.Settled)
            };
        }
    }
}
