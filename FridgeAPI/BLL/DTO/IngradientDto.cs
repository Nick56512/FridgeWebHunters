using FridgeOfWebHunter.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class IngradientDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Icon { get; set; }

        public int CategoryId { get; set; }
    }
}
