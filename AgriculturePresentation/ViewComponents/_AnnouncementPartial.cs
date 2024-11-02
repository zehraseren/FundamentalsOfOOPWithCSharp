using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _AnnouncementPartial : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _AnnouncementPartial(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            
            var values = _announcementService.GetList();
            return View(values);
        }
    }
}
