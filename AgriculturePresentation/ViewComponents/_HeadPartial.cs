using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.ViewComponents
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
