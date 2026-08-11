using ChubbInsuranceClaim.src.Application.DTO.Claims;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChubbInsuranceClaim.src.API.Controllers
{
    [ApiController]
    [Route("api/claims")]
    [Authorize]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;
        private readonly IClaimWorkflowService _workflowService;

        public ClaimsController(IClaimService claimService, IClaimWorkflowService workflowService)
        {
            _claimService = claimService;
            _workflowService = workflowService;
        }

        // Customer creates claim
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(CreateClaimRequest request)
        {
            int customerId = GetCurrentUserId();

            var result = await _claimService.CreateClaimAsync(customerId, request);

            return Ok(result);
        }

        // Customer views own claims
        [HttpGet("my")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> MyClaims()
        {
            int customerId = GetCurrentUserId();

            var result = await _claimService.GetMyClaimsAsync(customerId);

            return Ok(result);
        }

        // Get claim details
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _claimService.GetByIdAsync(id);

            return Ok(result);
        }

        // Update claim
        [HttpPut("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Update(int id, UpdateClaimRequest request)
        {
            await _claimService.UpdateClaimAsync(id, request);

            return Ok(new
            {
                message = "Claim updated successfully."
            });
        }

        // Assign claim to officer
        [HttpPut("{id}/assign")]
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> Assign(int id, AssignClaimRequest request)
        {

            await _workflowService.AssignClaimAsync(id, request);

            return Ok(new
            {
                message = "Claim assigned successfully."
            });
        }

        // Start claim review
        [HttpPut("{id}/review")]
        [Authorize(Roles = "ClaimOfficer")]
        public async Task<IActionResult> Review(int id)
        {
            await _workflowService.StartReviewAsync(id);

            return Ok(new
            {
                message = "Claim moved to review."
            });
        }

        // Request additional information
        [HttpPut("{id}/request-information")]
        [Authorize(Roles = "ClaimOfficer")]
        public async Task<IActionResult> RequestInformation(int id, ClaimInformationRequest request)
        {
            await _workflowService.RequestInformationAsync(id, request);

            return Ok(new
            {
                message = "Additional information requested."
            });
        }


        // Customer submits requested information
        [HttpPut("{id}/submit-information")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> SubmitInformation(int id, ClaimInformationRequest request)
        {
            await _workflowService.SubmitInformationAsync(id, request);

            return Ok(new
            {
                message = "Information submitted."
            });
        }

        // Approve claim
        [HttpPut("{id}/approve")]
        [Authorize(Roles = "ClaimOfficer")]
        public async Task<IActionResult> Approve(int id, ClaimDecisionRequest request)
        {
            await _workflowService.ApproveClaimAsync(id, request);

            return Ok(new
            {
                message = "Claim approved."
            });
        }

        // Reject claim
        [HttpPut("{id}/reject")]
        [Authorize(Roles = "ClaimOfficer")]
        public async Task<IActionResult> Reject(int id, ClaimDecisionRequest request)
        {
            await _workflowService.RejectClaimAsync(id, request);

            return Ok(new
            {
                message = "Claim rejected."
            });
        }

        // Settlement
        [HttpPut("{id}/settle")]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Settle(int id, ClaimDecisionRequest request)
        {
            await _workflowService.SettleClaimAsync(id, request);

            return Ok(new
            {
                message = "Claim settled."
            });
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}