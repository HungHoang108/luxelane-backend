using Luxelane.Db;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;

namespace Luxelane.Repositories.CategoryRepo
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(DataContext context, ILogger<BaseRepo<Category>> logger) : base(context, logger)
        {
        }

    }
}