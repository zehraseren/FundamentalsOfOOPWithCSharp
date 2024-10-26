using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
