using FridgeOfWebHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class IngradientRecipeDto
    {
        public int Id { get; set; }
        public int IngradientId { get; set; }
        public IngradientDto IngradientDto { get; set; }
        public int RecipeId { get; set; }

        public RecipeDto RecipeDto { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
