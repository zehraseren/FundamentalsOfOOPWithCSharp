using DemoProduct.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace DemoProduct.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Identity kütüphanesi kullanılacağı için async olaral tanımlanmalıdır.
        public async Task<IActionResult> Index(UserRegisterViewModel urvm)
        {
            AppUser user = new AppUser()
            {
                Name = urvm.Name,
                Surname = urvm.Surname,
                UserName = urvm.UserName,
                Email = urvm.Mail,
            };
            if (urvm.Password == urvm.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, urvm.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(urvm);
        }
    }
}
