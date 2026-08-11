using ChubbInsuranceClaim.src.Application.Common.Models;
using ChubbInsuranceClaim.src.Application.DTO.Authentication;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
