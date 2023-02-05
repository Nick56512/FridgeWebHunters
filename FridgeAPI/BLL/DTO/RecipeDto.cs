using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Instruction { get; set; }
        public double Difficulty { get; set; }
        public string Image { get; set; }
        public UserDto Owner { get; set; }
    }
}
