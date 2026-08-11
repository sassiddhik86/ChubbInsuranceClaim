namespace ChubbInsuranceClaim.src.Application.DTO.Claims
{
    public class CreateClaimRequest
    {
        public int IncidentId { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
