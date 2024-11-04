using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
