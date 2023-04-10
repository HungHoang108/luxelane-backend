using Luxelane.DTOs;
using Luxelane.Models;

namespace Luxelane.Services.UserService
{
    public interface ITokenService
    {
        Task<UserSignInReadDto> GenerateTokenAsync(User user);
    }
}