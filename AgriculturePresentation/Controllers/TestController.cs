using Agriculture.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Presentation.Controllers
{
    public class TestController : Controller
    {
        private readonly IServiceService _serviceService;

        public TestController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetList();
            return View(values);
        }
    }
}
