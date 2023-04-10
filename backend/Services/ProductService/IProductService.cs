using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.BaseService;

namespace Luxelane.Services.ProductService
{
    public interface IProductService : IBaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>
    {
        
    }
}