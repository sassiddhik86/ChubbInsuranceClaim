namespace ChubbInsuranceClaim.src.Application.DTO.Authentication
{
    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string EmployeeNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
