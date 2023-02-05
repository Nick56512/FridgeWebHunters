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
    public class IngradientService : GenericService<Ingredient, IngradientDto>
    {
        public IngradientService(IRepository<Ingredient> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<IngradientDto>> GetIngredientByCategoryAsync(int categoryId) {
            var result = await GetAllAsync();

            result = result.Where(r => r.CategoryId == categoryId);

            return result;
        }
    }
}
