namespace ChubbInsuranceClaim.src.Application.DTO.Claims
{
    public class ClaimResponse
    {
        public int Id { get; set; }

        public string ClaimNumber { get; set; } = string.Empty;

        public decimal ClaimAmount { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Customer { get; set; } = string.Empty;

        public string IncidentLocation { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
