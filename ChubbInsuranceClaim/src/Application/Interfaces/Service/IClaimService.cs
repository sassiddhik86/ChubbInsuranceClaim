using ChubbInsuranceClaim.src.Application.Common.Models;
using ChubbInsuranceClaim.src.Application.DTO.Claims;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IClaimService
    {
        Task<ClaimResponse> CreateClaimAsync(int customerId, CreateClaimRequest request);
        Task<List<ClaimResponse>> GetMyClaimsAsync(int customerId);
        Task<ClaimResponse> GetByIdAsync(int claimId);
        Task UpdateClaimAsync(int claimId, UpdateClaimRequest request);
        Task DeleteClaimAsync(int claimId);
    }
}
