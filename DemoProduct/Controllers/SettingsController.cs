using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
