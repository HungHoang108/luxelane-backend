using Luxelane.Db;
using Luxelane.Models;
using Luxelane.Repositories.AddressRepo;
using Luxelane.Repositories.BaseRepo;

namespace Luxelane.Repositories.AddressRepo
{
    public class AddressRepo : BaseRepo<Address>, IAddressRepo
    {
        public AddressRepo(DataContext context, ILogger<BaseRepo<Address>> logger) : base(context, logger)
        {
        }
    }
}