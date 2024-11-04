using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.ViewComponents
{
    public class _DashboardScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
