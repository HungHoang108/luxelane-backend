using Luxelane.Db;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using Luxelane.Common;

namespace Luxelane.Repositories.ProductRepo
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {

        public ProductRepo(DataContext context, ILogger<BaseRepo<Product>> logger) : base(context, logger)
        {
        }
        // public string Search { get; set; } = string.Empty;
        public async Task<ICollection<Product>> GetAllProductAsync(ProductQueryOptions options)
        {
            var query = _context.Set<Product>().AsNoTracking();

            if (!string.IsNullOrEmpty(options.SortByProduct))
            {
                switch (options.Sort)
                {
                    case "Name":
                        query = options.OrderByProduct == OrderByProduct.DESC ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                        break;

                    case "Price":
                        query = options.SortBy == SortBy.DESC ? query.OrderByDescending(x => x.Price) : query.OrderBy(x => x.Price);
                        break;

                    case "Quantity":
                        query = options.SortBy == SortBy.DESC ? query.OrderByDescending(x => x.Quantity) : query.OrderBy(x => x.Quantity);
                        break;

                    default:
                        break;
                }
            }
            // if (!string.IsNullOrEmpty(search))
            // {
            //     query = query.Where(product => product.Name.Contains(search));
            // }
            query = query.Skip(options.Skip).Take(options.Limit);
            return await query.ToListAsync();
        }
        public override async Task<ICollection<Product>> GetAllAsync(QueryOptions options)
        {
            var query = _context.Set<Product>().AsNoTracking();

            if (!string.IsNullOrEmpty(options.Sort))
            {
                switch (options.Sort)
                {
                    case "Name":
                        query = options.SortBy == SortBy.DESC ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                        break;

                    case "Price":
                        query = options.SortBy == SortBy.DESC ? query.OrderByDescending(x => x.Price) : query.OrderBy(x => x.Price);
                        break;

                    case "Quantity":
                        query = options.SortBy == SortBy.DESC ? query.OrderByDescending(x => x.Quantity) : query.OrderBy(x => x.Quantity);
                        break;

                    default:
                        break;
                }
            }
            // if (!string.IsNullOrEmpty(search))
            // {
            //     query = query.Where(product => product.Name.Contains(search));
            // }
            query = query.Skip(options.Skip).Take(options.Limit);
            return await query.ToListAsync();
        }

        public override async Task<Product> UpdateAsync(int id, Product request)
        {
            var item = await GetAsync(id);
            request.Id = item!.Id;
            request.Images = item.Images;
            request.CategoryId = item.CategoryId;
            _context.Entry(item).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}