using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProduct.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jm = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = _customerManager.GetCustomersListWithJob();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            JobManager jm = new JobManager(new EfJobDal());
            List<SelectListItem> values = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Value = x.JobId.ToString(),
                                               Text = x.JobName,
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            ModelState.Clear();
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(customer);
            if (results.IsValid)
            {
                _customerManager.TInsert(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerManager.TGetById(id);
            _customerManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            JobManager jm = new JobManager(new EfJobDal());
            List<SelectListItem> values = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Value = x.JobId.ToString(),
                                               Text = x.JobName,
                                           }).ToList();
            ViewBag.v = values;
            var value = _customerManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerManager.TUpdate(customer);
            return RedirectToAction("Index");
        }
    }
}
