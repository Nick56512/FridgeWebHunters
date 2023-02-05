using FridgeOfWebHunter.Areas.Identity.Data;

namespace FridgeOfWebHunter.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Instruction { get; set; }
        public double Difficulty { get; set; }
        public string Image { get; set; }
        public User Owner { get; set; }

    }
}
