using AutoMapper;
using BLL.DTO;
using BLL.Services;
using BLL.Services.IdentityServices;
using FridgeOfWebHunter.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FridgeOfWebHunter.Controllers.ApiControllers
{

    [ApiController]
    [Route("api/r2/[controller]")]
    public class RecipeController : Controller
    {
        UserService userManager;
        RecipeService recipeService;
        IngradientRecipeService ingradientRecipeService;
        IngradientService ingradientService;

        public RecipeController(UserService userManager, RecipeService recipeService, IngradientRecipeService ingradientRecipeService, IngradientService ingradientService)
        {
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.ingradientRecipeService = ingradientRecipeService;
            this.ingradientService = ingradientService;
        }

        [HttpGet]
        [Route("/searchbyname")]
        public async Task<ActionResult> SearchByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var response = await recipeService.GetRecipeByNameAsync(name);
                return Json(response);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("/addrecipe")]
        public async Task<ActionResult> AddRecipe(RecipeDto recipeDto)
        {
            if (recipeDto != null)
            {
                await recipeService.AddAsync(recipeDto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/get")]
        public async Task<ActionResult> AllRecipes()
        {
            var result = await recipeService.GetAllAsync();

            if (!result.Equals(null))
                return Json(result);

            return BadRequest();
        }

        [HttpGet]
        [Route("/get/{id}")]
        public async Task<ActionResult> GetRecipeById(int id)
        {
            var resultRecipe = await recipeService.GetAsync(id);

            var resultIngrRecipe = await ingradientRecipeService.GetByRecipeId(id);

            List<Tuple<IngradientDto, IngradientRecipeDto>> resultTuple = new List<Tuple<IngradientDto, IngradientRecipeDto>>();

            foreach (var item in resultIngrRecipe) {
                resultTuple.Add(Tuple.Create(ingradientService.Get(item.IngradientId), item));
            }

            Tuple<RecipeDto, IEnumerable<Tuple<IngradientDto,IngradientRecipeDto>>> response = Tuple.Create(resultRecipe, resultTuple.AsEnumerable());

            if (!response.Equals(null))
                return Json(response);

            return BadRequest();
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await recipeService.DeleteAsync(id);
            if (response.Equals(null))
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("/usercancook")]
        public async Task<ActionResult> GetRecipeUserCanCook()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string? currentUserEmail = claimsIdentity?.FindFirst(ClaimTypes.Email)?.Value;
            if (!String.IsNullOrEmpty(currentUserEmail))
            {
                UserDto user = await userManager.FindByEmailAsync(currentUserEmail);
                var result = await recipeService.GetRecipeUserCanCookAsync(user);

                return Json(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/userrecipe")]
        public async Task<ActionResult> GetUserRecipes()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string? currentUserEmail = claimsIdentity?.FindFirst(ClaimTypes.Email)?.Value;
            if (!String.IsNullOrEmpty(currentUserEmail))
            {
                UserDto user = await userManager.FindByEmailAsync(currentUserEmail);
                var result = await recipeService.GetUsersRecipeAsync(user);

                return Json(result);
            }

            return BadRequest();
        }
    }
}