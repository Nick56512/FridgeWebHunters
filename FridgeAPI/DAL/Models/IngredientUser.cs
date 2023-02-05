using FridgeOfWebHunter.Areas.Identity.Data;

namespace FridgeOfWebHunter.Models
{
    public class IngredientUser
    {
        public int Id { get; set; }

        public Ingredient Ingredient { get; set; }
        public int IngradientId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
