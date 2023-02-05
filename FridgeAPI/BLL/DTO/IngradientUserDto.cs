using FridgeOfWebHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class IngradientUserDto
    {
        public int Id { get; set; }
        public int IngradientId { get; set; }
        public IngradientDto IngredientDto { get; set; }
        public string UserId { get; set; }
        public UserDto UserDto { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
