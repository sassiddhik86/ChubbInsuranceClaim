using ChubbInsuranceClaim.src.Application.DTO.Claims;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Application.Services
{
    public class ClaimWorkflowService : IClaimWorkflowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClaimWorkflowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AssignClaimAsync(int claimId, AssignClaimRequest request)
        {

            var claim = await _unitOfWork.Claims.GetByIdAsync(claimId);

            if (claim == null)
                throw new Exception("Claim not found.");

            var officer = await _unitOfWork.Users.GetByIdAsync(request.OfficerId);

            if (officer == null)
                throw new Exception("Officer not found.");

            var assignment =
                new ClaimAssignment
                {
                    ClaimId = claimId,
                    OfficerId = request.OfficerId,
                    AssignedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow
                };


            await _unitOfWork.ClaimAssignments.AddAsync(assignment);

            claim.Status = ClaimStatus.Assigned;

            await AddHistory(claim, ClaimStatus.Assigned, "Claim assigned to officer.");
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task StartReviewAsync(int claimId)
        {
            var claim = await _unitOfWork.Claims.GetByIdAsync(claimId);
            ValidateClaim(claim);

            claim!.Status = ClaimStatus.UnderReview;

            await AddHistory(claim, ClaimStatus.UnderReview, "Claim review started.");
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RequestInformationAsync(int claimId, ClaimInformationRequest request)
        {
            var claim = await GetClaim(claimId);

            claim.Status = ClaimStatus.NeedMoreInformation;

            await AddHistory(claim, ClaimStatus.NeedMoreInformation, request.Information);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task SubmitInformationAsync(int claimId, ClaimInformationRequest request)
        {
            var claim = await GetClaim(claimId);

            claim.Status = ClaimStatus.InformationReceived;

            await AddHistory(claim, ClaimStatus.InformationReceived, request.Information);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ApproveClaimAsync(int claimId, ClaimDecisionRequest request)
        {
            var claim = await GetClaim(claimId);

            if (claim.Status == ClaimStatus.Rejected)
            {
                throw new Exception("Rejected claim cannot be approved.");
            }

            claim.Status = ClaimStatus.Approved;

            await AddHistory(claim, ClaimStatus.Approved, request.Remarks);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RejectClaimAsync(int claimId, ClaimDecisionRequest request)
        {
            var claim = await GetClaim(claimId);

            claim.Status = ClaimStatus.Rejected;

            await AddHistory(claim, ClaimStatus.Rejected, request.Remarks);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task SettleClaimAsync(int claimId, ClaimDecisionRequest request)
        {
            var claim = await GetClaim(claimId);

            if (claim.Status != ClaimStatus.Approved)
            {
                throw new Exception("Only approved claims can be settled.");
            }

            claim.Status = ClaimStatus.Settled;

            await AddHistory(claim, ClaimStatus.Settled, request.Remarks);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<InsuranceClaim> GetClaim(int id)
        {
            var claim = await _unitOfWork.Claims.GetByIdAsync(id);

            ValidateClaim(claim);

            return claim!;
        }

        private static void ValidateClaim(
            InsuranceClaim? claim)
        {
            if (claim == null)
            {
                throw new Exception(
                    "Claim not found.");
            }
        }

        private async Task AddHistory(InsuranceClaim claim, ClaimStatus status, string remarks)
        {
            var history =
                new ClaimStatusHistory
                {
                    ClaimId = claim.Id,
                    Status = status,
                    Remarks = remarks,
                    CreatedDate = DateTime.UtcNow
                };


            //await _unitOfWork
            //    .ClaimStatusHistories
            //    .AddAsync(history);
        }
    }
}
