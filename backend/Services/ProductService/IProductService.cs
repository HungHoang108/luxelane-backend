using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.BaseService;
using Luxelane.Common;

namespace Luxelane.Services.ProductService
{
    public interface IProductService : IBaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>
    {
        Task<ICollection<ProductReadDto>> GetAllProductAsync(ProductQueryOptions options);

    }
}