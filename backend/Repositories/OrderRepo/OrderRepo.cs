using Luxelane.Db;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Repositories.BaseRepo;

namespace Luxelane.Repositories.OrderRepo
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {

        public OrderRepo(DataContext context, ILogger<BaseRepo<Order>> logger) : base(context, logger)
        {
        }

        public async Task<Order> UpdateOrderStatus(int Id, OrderStatus updateStatus)
        {
            var order = await _context.Orders.FindAsync(Id);
            order!.OrderStatus = updateStatus;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}