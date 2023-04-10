using Luxelane.DTOs;

namespace Luxelane.Services.UserService
{
    public interface IUserService
    {
        Task<UserSignUpReadDto?> SignUpAsync(UserSignUpDto request);
        Task<UserSignInReadDto?> SignInAsync(UserSignInDto request);
        Task<UserReadDto?> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<UserSignInReadDto> UpdateAsync(int id, UserUpdateDto update);
        Task<ICollection<UserReadDto>> GetAllAsync();
        Task<UserProfileDto> GetProfile();
    }
}