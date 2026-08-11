namespace ChubbInsuranceClaim.src.Application.DTO.Authentication
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
    }
}
