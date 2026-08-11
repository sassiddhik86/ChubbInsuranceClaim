namespace ChubbInsuranceClaim.src.Application.DTO.Claims
{
    public class UpdateClaimRequest
    {
        public decimal ClaimAmount { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
