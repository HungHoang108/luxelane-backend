using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public int PostalCode { get; set; }
        public string Country { get; set; } = null!;
        
        [NotMapped]
        public User? User { get; set; } = null!;
        public int UserId { get; set; }

    }
}