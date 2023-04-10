using AutoMapper;
using Luxelane.DTOs;
using Luxelane.Helpers;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Repositories.ProductRepo;
using Luxelane.Services.BaseService;

namespace Luxelane.Services.ProductService
{
    public class ProductService : BaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>,
            IProductService
    {
        protected readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo, IMapper mapper, IBaseRepo<Product> repo, ILogger<BaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>> logger) : base(mapper, repo, logger)
        {
            _productRepo = productRepo;
        }

        public override async Task<ICollection<ProductReadDto>> GetAllAsync(QueryOptions options)
        {
            var data = await _productRepo.GetAllAsync(options);
            return _mapper.Map<ICollection<ProductReadDto>>(data);
        }

        public override async Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto request)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                throw ServiceException.NotFound();
            }
            var updateData = _mapper.Map<Product>(request);
            var result = await _productRepo.UpdateAsync(id, updateData);
            return _mapper.Map<ProductReadDto>(result);
        }
    }
}
