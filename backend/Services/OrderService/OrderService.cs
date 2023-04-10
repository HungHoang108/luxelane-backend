using AutoMapper;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Services.BaseService;
using Luxelane.Repositories.OrderRepo;
using Luxelane.Helpers;

namespace Luxelane.Services.OrderService
{
    public class OrderService : BaseService<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>, IOrderService
    {
        protected readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo, IMapper mapper, IBaseRepo<Order> repo, ILogger<BaseService<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>> logger) : base(mapper, repo, logger)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderReadDto> UpdateOrderStatus(int id, OrderStatus status)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                throw ServiceException.NotFound();
            }
            var order = await _orderRepo.UpdateOrderStatus(id, status);
            var result = _mapper.Map<OrderReadDto>(order);
            return result;
        }
    }
}

