using Luxelane.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class Order : BaseModel
    {
        [NotMapped]
        public User? User { get; set; } = null!;
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; }
    }
}