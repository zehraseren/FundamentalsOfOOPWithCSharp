using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Agriculture.Presentation.Models;

namespace Agriculture.Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditvm = new UserEditViewModel();
            userEditvm.Mail = values.Email;
            userEditvm.Phone = values.PhoneNumber;
            return View(userEditvm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEdit)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = userEdit.Mail;
            values.PhoneNumber = userEdit.Phone;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEdit.Password);

            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
