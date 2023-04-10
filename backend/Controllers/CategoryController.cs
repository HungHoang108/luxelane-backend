using Luxelane.Models;
using Luxelane.Services.CategoryService;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Controllers
{
    public class CategoryController : BaseController<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}