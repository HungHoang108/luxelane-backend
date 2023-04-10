using System.ComponentModel.DataAnnotations;

namespace Luxelane.DTOs
{
    public class CategoryDto
    {
        public class CategoryBaseDto
        {
            [StringLength(500, MinimumLength = 3)]
            public string Name { get; set; } = null!;
            [Url]
            public string Image { get; set; } = null!;
        }

        public class CategoryCreateDto : CategoryBaseDto
        {
        }

        public class CategoryReadDto : CategoryBaseDto
        {
            public int Id { get; set; }
            public ICollection<ProductReadDto> Product { get; set; } = null!;
        }

        public class CategoryUpdateDto : CategoryBaseDto
        {
        }
    }
}