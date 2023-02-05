using Microsoft.AspNetCore.Mvc;

namespace FridgeOfWebHunter.Controllers.ApiControllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
