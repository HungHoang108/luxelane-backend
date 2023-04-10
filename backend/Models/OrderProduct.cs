using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class OrderProduct : BaseModel
    {
        public int Quantity { get; set; }
        [NotMapped]
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public Order? Order { get; set; }
        public int OrderId { get; set; }

    }
}