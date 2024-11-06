using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Agriculture.Presentation.Models;
using Microsoft.AspNetCore.Authorization;

namespace Agriculture.Presentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.username, login.password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel register)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "1",
                UserName = register.username,
                Email = register.mail,
            };

            if (register.password == register.passwordConfirm)
            {
                var result = await _userManager.CreateAsync(user, register.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(register);
        }
    }
}
