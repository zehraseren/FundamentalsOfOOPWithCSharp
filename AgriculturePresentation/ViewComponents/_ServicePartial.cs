using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _ServicePartial : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServicePartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceService.GetList();
            return View(values);
        }
    }
}
