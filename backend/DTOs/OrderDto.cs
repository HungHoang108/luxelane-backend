using System.ComponentModel.DataAnnotations;
using Luxelane.Models.Enum;

namespace Luxelane.DTOs
{
    public class OrderBaseDto
    {
        public int UserId { get; set; }
        
        [Range(1.00, 15000.00)]
        public decimal TotalPrice { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderCreateDto : OrderBaseDto
    {
    }

    public class OrderReadDto : OrderBaseDto
    {
        public int Id { get; set; }
        public ICollection<OrderProductReadDto> OrderProducts { get; set; } = null!;

    }

    public class OrderUpdateDto : OrderBaseDto
    {
    }
}