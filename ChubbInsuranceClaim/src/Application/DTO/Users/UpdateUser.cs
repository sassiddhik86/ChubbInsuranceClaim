namespace ChubbInsuranceClaim.src.Application.DTO.Users
{
    public class UpdateUser
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public Guid TeamId { get; set; }
        public Guid RoleId { get; set; }
    }
}
