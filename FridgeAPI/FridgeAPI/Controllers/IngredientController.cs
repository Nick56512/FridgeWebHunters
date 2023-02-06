using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAPI.Controllers
{
    [ApiController]
    [Route("api/i2/[controller]")]
    public class IngredientController : Controller
    {
        IngradientService ingredientService;

        public IngredientController(IngradientService service) {
            ingredientService = service;
        }

        [HttpGet]
        [Route("/getall")]
        public async Task<ActionResult> GetAll() {
            var result = await ingredientService.GetAllAsync();

            if (result != null)
                return Json(result);

            return BadRequest();
        }

        [HttpGet]
        [Route("/getbycategory/{category}")]
        public async Task<ActionResult> GetByCategory(CategoryDto categoryDto) {
            var result = await ingredientService.GetIngredientByCategoryAsync(categoryDto.Id);

            if (result != null) 
                return Json(result);
            
            return BadRequest();
        }
    }
}
