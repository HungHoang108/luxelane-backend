using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Common;

namespace Luxelane.Repositories.ProductRepo
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task<ICollection<Product>> GetAllProductAsync(ProductQueryOptions options);
    }
}