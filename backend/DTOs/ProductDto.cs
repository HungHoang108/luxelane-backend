using System.ComponentModel.DataAnnotations;

namespace Luxelane.DTOs
{

    public class ProductBaseDto
    {
        [StringLength(500, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [StringLength(10000, MinimumLength = 0)]
        public string Description { get; set; } = null!;

        [Range(1.00, 5000.00)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public int Quantity { get; set; }

        public List<string> Images { get; set; } = null!;
    }

    public class ProductCreateDto : ProductBaseDto
    {
        public int CategoryId { get; set; }
    }

    public class ProductReadDto : ProductBaseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductUpdateDto
    {
        [StringLength(500, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [StringLength(10000, MinimumLength = 0)]
        public string Description { get; set; } = null!;

        [Range(1.00, 5000.00)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public int Quantity { get; set; }
        // public List<string> Images { get; set; } = null!;

    }
}
