using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
        
        [NotMapped]
        public Category? Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public List<string> Images { get; set; } = null!;
    }
}