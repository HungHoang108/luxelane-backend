namespace Luxelane.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public ICollection<Product> Product { get; set; } = null!;
    }
}