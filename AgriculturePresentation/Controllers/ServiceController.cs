using Microsoft.AspNetCore.Mvc;
using Agriculture.Presentation.Models;
using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View(new AddServiceViewModel());
        }

        /*
         * Buradaki new Service() ifadesi, AddServiceViewModel'den alınan verileri Service class'ına dönüştürmek için kullanılır. Bu işlem, formdan gelen verileri doğrudan Service class'ı nesnesine aktarmak amacıyla yapılır.
         * AddServiceViewModel yalnızca kullanıcıdan alınan verileri tutar (örneğin, başlık, resim, açıklama gibi).
         * Service class'ı ise veritabanına kaydedilecek tam nesneyi ifade eder.
         */
        [HttpPost]
        public IActionResult AddService(AddServiceViewModel asvm)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = asvm.Title,
                    Image = asvm.Image,
                    Description = asvm.Description,
                });
                return RedirectToAction("Index");
            }
            return View(asvm);
        }

        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
