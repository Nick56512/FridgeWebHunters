using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;

namespace FridgeOfWebHunter.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
