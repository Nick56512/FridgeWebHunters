namespace FridgeOfWebHunter.Models
{
    public class IngredientRecipe
    {
        public int Id { get; set; } 
        public int IngradientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
