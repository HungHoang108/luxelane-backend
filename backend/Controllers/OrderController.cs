using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{
    public class OrderController : BaseController<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderService service) : base(service)
        {
            _orderService = service;
            _logger = logger;
        }

        [HttpPatch("orderStatus/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<OrderReadDto> UpdateOrderStatus(int id, [FromBody] OrderStatus newStatus)
        {
            var result = await _orderService.UpdateOrderStatus(id, newStatus);
            _logger.LogInformation("Result: {@result} 1", result.OrderStatus);

            return result;
        }
    }
}