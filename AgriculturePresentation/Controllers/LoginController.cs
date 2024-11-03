using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
