using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _SocialMediaPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _SocialMediaPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.GetList();
            return View(values);
        }
    }
}
