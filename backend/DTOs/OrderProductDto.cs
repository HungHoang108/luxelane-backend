using System.ComponentModel.DataAnnotations;

namespace Luxelane.DTOs
{
    public class OrderProductBaseDto
    {
        [Range(1, 50)]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }

    public class OrderProductCreateDto : OrderProductBaseDto
    {
    }

    public class OrderProductReadDto : OrderProductBaseDto
    {
        public int Id { get; set; }
    }

    public class OrderProductUpdateDto : OrderProductBaseDto
    {
    }
}