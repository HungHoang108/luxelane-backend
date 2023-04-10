using Luxelane.Models;
using Luxelane.Services.BaseService;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Services.CategoryService
{
    public interface ICategoryService : IBaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>
    {

    }
}