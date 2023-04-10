using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Services.BaseService;
using Microsoft.AspNetCore.Mvc;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Services.OrderService
{
    public interface IOrderService : IBaseService<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>
    {
        public Task<OrderReadDto> UpdateOrderStatus(int Id, OrderStatus status);
  

    }
}