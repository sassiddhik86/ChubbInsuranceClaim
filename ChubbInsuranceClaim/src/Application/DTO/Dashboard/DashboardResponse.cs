namespace ChubbInsuranceClaim.src.Application.DTO.Dashboard
{
    public class DashboardResponse
    {
        public int TotalClaims { get; set; }
        public int PendingClaims { get; set; }
        public int ApprovedClaims { get; set; }
        public int RejectedClaims { get; set; }
        public int SettledClaims { get; set; }
    }
}
