using ChubbInsuranceClaim.src.Application.DTO.Claims;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IClaimWorkflowService
    {
        Task AssignClaimAsync(
            int claimId,
            AssignClaimRequest request);

        Task StartReviewAsync(
            int claimId);

        Task RequestInformationAsync(
            int claimId,
            ClaimInformationRequest request);

        Task SubmitInformationAsync(
            int claimId,
            ClaimInformationRequest request);

        Task ApproveClaimAsync(
            int claimId,
            ClaimDecisionRequest request);

        Task RejectClaimAsync(
            int claimId,
            ClaimDecisionRequest request);

        Task SettleClaimAsync(
            int claimId,
            ClaimDecisionRequest request);
    }
}
