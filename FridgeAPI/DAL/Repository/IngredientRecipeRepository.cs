using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;

namespace FridgeOfWebHunter.Repository
{
    public class IngredientRecipeRepository : Repository<IngredientRecipe>
    {
        public IngredientRecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
