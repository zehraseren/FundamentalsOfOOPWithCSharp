using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
