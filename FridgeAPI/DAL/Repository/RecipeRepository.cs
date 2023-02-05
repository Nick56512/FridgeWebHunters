using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;

namespace FridgeOfWebHunter.Repository
{
    public class RecipeRepository : Repository<Recipe>
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
