using BLL.DTO;
using BLL.Services;
using BLL.Services.IdentityServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FridgeAPI.Controllers
{
    [ApiController]
    [Route("api/i2/[controller]")]
    public class IngredientController : Controller
    {
        IngradientService ingredientService;
        IngradientUserService ingradientUserService;
        UserService userService;
        public IngredientController(IngradientService service,
            IngradientUserService ingradientUserService,
            UserService userService)
        {
            ingredientService = service;
            this.ingradientUserService = ingradientUserService;
            this.userService = userService;
        }

        [HttpGet("/getall")]
        public async Task<ActionResult> GetAll() {
            var result = await ingredientService.GetAllAsync();

            if (result != null)
                return Json(result);

            return BadRequest();
        }

        [HttpGet]
        [Route("/getbycategory/{categoryId}")]
        public async Task<ActionResult> GetByCategory(int categoryId) {
            var result = await ingredientService.GetIngredientByCategoryAsync(categoryId);

            if (result != null) 
                return Json(result);
            
            return BadRequest();
        }


        [HttpGet("/getMyIngredients")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMyIngredients()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string? currentUserEmail = claimsIdentity?.FindFirst(ClaimTypes.Email)?.Value;
            if (!String.IsNullOrEmpty(currentUserEmail))
            {
                UserDto user = await userService.FindByEmailAsync(currentUserEmail);
                var collection = (await ingradientUserService.GetUserIngredientsByUserIdAsync(user.Id));
                var result= collection.Select(x=>ingredientService.Get(x.IngradientId));

                return Ok(result);
            }
            return BadRequest();

        }
    }
}
