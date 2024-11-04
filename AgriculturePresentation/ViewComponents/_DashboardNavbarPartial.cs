using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.ViewComponents
{
    public class _DashboardNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
