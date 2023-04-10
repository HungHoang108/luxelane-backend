using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.OrderProductService;

namespace Luxelane.Controllers
{
    public class OrderProductController : BaseController<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>
    {
        public OrderProductController(IOrderProductService service) : base(service)
        {
        }
    }
}