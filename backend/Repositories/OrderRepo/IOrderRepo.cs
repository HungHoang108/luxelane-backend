using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Repositories.BaseRepo;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Repositories.OrderRepo
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<Order> UpdateOrderStatus(int Id, OrderStatus status);
        
    }
}