using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Models;

namespace FridgeOfWebHunter.Repository
{
    public class IngredientRepository : Repository<Ingredient>
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
