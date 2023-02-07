using AutoMapper;
using BLL.DTO;
using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Interfaces;
using FridgeOfWebHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IngradientRecipeService : GenericService<IngredientRecipe, IngradientRecipeDto>
    {
        public IngradientRecipeService(IRepository<IngredientRecipe> repository) : base(repository)
        {
            MapperConfiguration configuration = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Recipe, RecipeDto>();
                opt.CreateMap<RecipeDto, Recipe>();

                opt.CreateMap<Ingredient, IngradientDto>();
                opt.CreateMap<IngradientDto, Ingredient>();

                opt.CreateMap<IngredientRecipe, IngradientRecipeDto>();
                opt.CreateMap<IngradientRecipeDto, IngredientRecipe>();
            });
            mapper = new Mapper(configuration);
        }

        public Task<IEnumerable<IngradientRecipeDto>> GetByRecipeId(int id) {
        
            return Task.Run(async () => {
                var result = await GetAllAsync();
                result = result.Where(r => r.RecipeId==id);
                return result;
            });
        }
    }
}
