using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;

namespace FridgeOfWebHunter.Repository
{
    public class IngredientUserRepository : Repository<IngredientUser>
    {
        public IngredientUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
