using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.GetList();
            return View(values);
        }
    }
}
