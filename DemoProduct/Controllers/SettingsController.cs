using DemoProduct.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace DemoProduct.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel uevm = new UserEditViewModel();
            uevm.Name = values.Name;
            uevm.Surname = values.Surname;
            uevm.Mail = values.Email;
            uevm.Gender = values.Gender;
            return View(uevm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel uevm)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = uevm.Name;
            user.Surname = uevm.Surname;
            user.Email = uevm.Mail;
            user.Gender = uevm.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, uevm.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Hata Mesajları
            }
            return View();
        }
    }
}
