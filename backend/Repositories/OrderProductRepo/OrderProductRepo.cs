using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Repositories.BaseRepo;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Repositories.OrderProductRepo
{
    public class OrderProductRepo : BaseRepo<OrderProduct>, IOrderProductRepo
    {
        public OrderProductRepo(DataContext context, ILogger<BaseRepo<OrderProduct>> logger) : base(context, logger)
        {
        }
    }
}