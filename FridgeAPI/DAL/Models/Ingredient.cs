namespace FridgeOfWebHunter.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Icon { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
