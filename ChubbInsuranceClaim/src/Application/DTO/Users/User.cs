namespace ChubbInsuranceClaim.src.Application.DTO.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
