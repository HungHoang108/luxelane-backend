using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Luxelane.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}