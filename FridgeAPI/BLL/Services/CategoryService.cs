using BLL.DTO;
using FridgeOfWebHunter.Interfaces;
using FridgeOfWebHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
