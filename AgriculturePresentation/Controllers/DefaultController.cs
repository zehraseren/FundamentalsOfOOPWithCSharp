using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Concrete;
using Agriculture.DataAccessLayer.Concrete.EntityFramework;

namespace Agriculture.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            var values = serviceManager.GetList();
            return View(values);
        }
    }
}
