using ChubbInsuranceClaim.src.Application.DTO.Claims;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Application.Services;

public class ClaimService : IClaimService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClaimService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClaimResponse> CreateClaimAsync(int customerId, CreateClaimRequest request)
    {
        // Validate customer
        var customer = await _unitOfWork.Users.GetByIdAsync(customerId);

        if (customer == null) { throw new Exception("Customer not found."); }

        // Validate incident
        var incident = await _unitOfWork.Incidents.GetByIdAsync(request.IncidentId);

        if (incident == null) { throw new Exception("Incident not found."); }

        var claim = new InsuranceClaim
        {
            ClaimNumber = GenerateClaimNumber(),
            ClaimAmount = request.ClaimAmount,
            Description = request.Description,
            Status = ClaimStatus.Submitted,
            UserId = customerId,
            IncidentId = request.IncidentId,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Claims.AddAsync(claim);

        // Add status history
        var history = new ClaimStatusHistory
        {
            Claim = claim,
            Status = ClaimStatus.Submitted,
            Remarks = "Claim submitted.",
            CreatedDate = DateTime.UtcNow
        };

        //await _unitOfWork
        //    .ClaimStatusHistories
        //    .AddAsync(history);

        await _unitOfWork.SaveChangesAsync();

        return MapResponse(claim);
    }

    public async Task<List<ClaimResponse>> GetMyClaimsAsync(int customerId)
    {
        var claims = await _unitOfWork.Claims.GetClaimsByCustomerAsync(customerId);

        return claims
            .Select(MapResponse)
            .ToList();
    }

    public async Task<ClaimResponse> GetByIdAsync(int claimId)
    {
        var claim = await _unitOfWork.Claims.GetByIdAsync(claimId);

        if (claim == null) { throw new Exception("Claim not found."); }

        return MapResponse(claim);
    }

    public async Task UpdateClaimAsync(int claimId, UpdateClaimRequest request)
    {
        var claim = await _unitOfWork.Claims.GetByIdAsync(claimId);

        if (claim == null) { throw new Exception("Claim not found."); }

        if (claim.Status != ClaimStatus.Draft &&
            claim.Status != ClaimStatus.Submitted)
        {
            throw new Exception("Claim cannot be updated after review started.");
        }

        claim.ClaimAmount = request.ClaimAmount;
        claim.Description = request.Description;
        claim.UpdatedDate = DateTime.UtcNow;
        _unitOfWork.Claims.Update(claim);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteClaimAsync(int claimId)
    {
        var claim = await _unitOfWork.Claims.GetByIdAsync(claimId);

        if (claim == null) { throw new Exception("Claim not found."); }

        if (claim.Status != ClaimStatus.Draft)
        { throw new Exception("Only draft claims can be deleted."); }

        _unitOfWork.Claims.Delete(claim);

        await _unitOfWork.SaveChangesAsync();
    }

    private static string GenerateClaimNumber()
    {
        return $"CLM-{DateTime.UtcNow:yyyyMMddHHmmss}";
    }

    private static ClaimResponse MapResponse(InsuranceClaim claim)
    {
        return new ClaimResponse
        {
            Id = claim.Id,
            ClaimNumber = claim.ClaimNumber,
            ClaimAmount = claim.ClaimAmount,
            Status = claim.Status.ToString(),
            Customer = claim.User?.FullName ?? string.Empty,
            IncidentLocation = claim.Incident?.Location ?? string.Empty,
            CreatedDate = claim.CreatedDate
        };
    }
}