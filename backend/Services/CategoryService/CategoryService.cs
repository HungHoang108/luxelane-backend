using AutoMapper;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Services.BaseService;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>, ICategoryService
    {
        public CategoryService(IMapper mapper, IBaseRepo<Category> repo, ILogger<BaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>> logger) : base(mapper, repo, logger)
        {
        }
    }
}

