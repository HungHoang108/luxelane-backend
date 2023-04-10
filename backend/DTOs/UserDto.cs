using System.ComponentModel.DataAnnotations;
using static Luxelane.DTOs.AddressDto;

namespace Luxelane.DTOs
{
    public class UserBaseDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

    }

    public class UserSignUpDto : UserBaseDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string UserName { get; set; } = null!;

        [StringLength(100, MinimumLength = 1)]
        public string Password { get; set; } = null!;

        [Url(ErrorMessage = "Image must be an Url")]
        public string Avatar { get; set; } = null!;
    }

    public class UserSignInDto
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class UserSignUpReadDto : UserBaseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }

    public class UserSignInReadDto
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }

    }

    public class UserReadDto : UserBaseDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; } = null!;
        public ICollection<AddressReadDto> Addresses { get; set; } = null!;
        public ICollection<OrderReadDto> Orders { get; set; } = null!;

    }

    public class UserUpdateDto : UserSignUpDto
    {
    }

    public class UserProfileDto : UserReadDto
    {
        public string Role { get; set; } = null!;

    }
}