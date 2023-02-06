using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FridgeOfWebHunter.Controllers.ApiControllers
{

    [ApiController]
    [Route("api/c2/[controller]")]
    public class CategoryController : Controller
    {
        CategoryService categoryService;
        public CategoryController(CategoryService categoryService) {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("/getcategories")]
        public async Task<ActionResult> GetAll() {
            var result = await categoryService.GetAllAsync();

            if(result != null)
                return Json(result);

            return BadRequest();
        }

        [HttpGet]
        [Route("/getcategories/{id}")]
        public ActionResult GetById(int id)
        {
            var result = categoryService.Get(id);

            if (result != null)
                return Json(result);

            return BadRequest();
        }
    }
}
