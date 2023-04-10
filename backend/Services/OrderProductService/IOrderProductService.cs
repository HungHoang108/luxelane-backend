using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Services.BaseService;
using Microsoft.AspNetCore.Mvc;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Services.OrderProductService
{
    public interface IOrderProductService : IBaseService<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>
    {
    }
}