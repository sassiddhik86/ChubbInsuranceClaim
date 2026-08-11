using ChubbInsuranceClaim.src.Application.Common.Models;
using ChubbInsuranceClaim.src.Application.DTO.Users;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<ApiResponse<IEnumerable<User>>> GetAllAsync();
        Task<ApiResponse<User>> GetByIdAsync(Guid id);
        //Task<ApiResponse<User>> CreateAsync(CreateUser dto);
        Task<ApiResponse<User>> UpdateAsync(Guid id, UpdateUser dto);
        Task<ApiResponse<bool>> DeleteAsync(Guid id);
    }
}
