using System.ComponentModel.DataAnnotations;

namespace Luxelane.DTOs
{
    public class AddressDto
    {
        public class AddressBaseDto
        {
            [StringLength(500, MinimumLength = 10)]
            public string Street { get; set; } = null!;

            [StringLength(100, MinimumLength = 3)]
            public string City { get; set; } = null!;

            [StringLength(100, MinimumLength = 3)]
            public int PostalCode { get; set; }
            
            [StringLength(100, MinimumLength = 3)]
            public string Country { get; set; } = null!;
        }

        public class AddressCreateDto : AddressBaseDto
        {
            public int UserId { get; set; }
        }

        public class AddressReadDto : AddressBaseDto
        {
            public int Id { get; set; }
            public int UserId { get; set; }
        }

        public class AddressUpdateDto : AddressBaseDto
        {
            public int UserId { get; set; }
        }
    }
}