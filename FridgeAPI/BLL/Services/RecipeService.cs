using BLL.DTO;
using FridgeOfWebHunter.Areas.Identity.Data;
using FridgeOfWebHunter.Interfaces;
using FridgeOfWebHunter.Models;
using FridgeOfWebHunter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecipeService : GenericService<Recipe, RecipeDto>
    {

        IngradientUserService ingradientUserService;
        IngradientRecipeService ingradientRecipeService;
        public RecipeService(IRepository<Recipe> repository, IngradientUserService ingradientUserService, IngradientRecipeService ingradientRecipeService) : base(repository)
        {
            this.ingradientUserService = ingradientUserService;
            this.ingradientRecipeService = ingradientRecipeService;
        }

        public Task<IEnumerable<RecipeDto>> GetRecipeByNameAsync(string name)
        {
            return Task.Run(async () => {
                var result = await this.GetAllAsync();
                result = result.Where(r => r.Name.Contains(name));
                return result;
            });
        }
        public Task<IEnumerable<RecipeDto>> GetUsersRecipeAsync(UserDto user)
        {
            return Task.Run(async () => {
                var result = await this.GetAllAsync();
                result = result.Where(r => r.Owner.Equals(user));
                return result;
            });
        }

        public Task<IEnumerable<RecipeDto>> GetRecipeUserCanCookAsync(UserDto user) {
            return Task.Run(async () => {
                var userIngredients = await ingradientUserService.GetUserIngredientsAsync(user);

                var userIngredientIds = userIngredients.Select(r => r.IngradientId);

                var recipeIngradients = await ingradientRecipeService.GetAllAsync();

                Dictionary<RecipeDto, List<int>> dictionary = new Dictionary<RecipeDto, List<int>>();

                foreach (var recipeIngredient in recipeIngradients) { 
                    if (!dictionary.ContainsKey(recipeIngredient.Recipe))
                        dictionary.Add(recipeIngredient.Recipe, new List<int>());

                    dictionary[recipeIngredient.Recipe].Add(recipeIngredient.IngradientId);
                }

                List<RecipeDto> result = new List<RecipeDto>();

                foreach (var pair in dictionary) {
                    if(UserHasIngredients(userIngredientIds, recipeIngredientIds: pair.Value))
                        result.Add(pair.Key);
                }

                return result.AsEnumerable();
            });
        }

        private bool UserHasIngredients(IEnumerable<int> userIngredientIds, IEnumerable<int> recipeIngredientIds) {
            foreach (var recipeId in recipeIngredientIds)
            {
                if(!userIngredientIds.Contains(recipeId))
                    return false;
            }
            return true;
        }
    }
}