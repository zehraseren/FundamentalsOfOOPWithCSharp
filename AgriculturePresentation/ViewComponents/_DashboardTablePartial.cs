using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _DashboardTablePartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DashboardTablePartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetList();
            return View(values);
        }
    }
}
