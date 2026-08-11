using ChubbInsuranceClaim.src.Application.DTO.Authentication;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace ChubbInsuranceClaim.src.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public AuthService(IUnitOfWork unitOfWork, JwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwt;
        }


        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            // Check duplicate email
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (existingUser != null)
            { throw new Exception("Email already registered."); }

            // Check duplicate employee number
            var existingEmployee = await _unitOfWork.Users.GetByEmployeeNumberAsync(request.EmployeeNumber);

            if (existingEmployee != null)
            { throw new Exception("Employee number already exists."); }

            // Default customer role
            var customerRole = await _unitOfWork.Roles.GetByIdAsync(2);

            if (customerRole == null)
            { throw new Exception("Customer role not configured."); }

            var user = new BusinessUser
            {
                FullName = request.FullName,
                EmployeeNumber = request.EmployeeNumber,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = customerRole.Id,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse
            {
                Token = string.Empty,
                Expiration = DateTime.Now,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user == null)
            { throw new Exception("Invalid email or password."); }

            if (!user.IsActive)
            { throw new Exception("User account is inactive."); }

            var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!passwordValid)
            { throw new Exception("Invalid email or password."); }

            var token = _jwtService.GenerateToken(user);

            return new AuthResponse
            {
                Token = token.Token,
                Expiration = DateTime.UtcNow.AddMinutes(120),
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.Name
            };
        }
    }
}
