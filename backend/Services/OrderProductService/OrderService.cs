using AutoMapper;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Services.BaseService;
using Luxelane.Repositories.OrderRepo;

namespace Luxelane.Services.OrderProductService
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>, IOrderProductService
    {
        public OrderProductService(IMapper mapper, IBaseRepo<OrderProduct> repo, ILogger<BaseService<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>> logger) : base(mapper, repo, logger)
        {
        }
    }
}

