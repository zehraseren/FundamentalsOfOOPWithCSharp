using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.ViewComponents
{
    public class _DashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
