using OOP_Project.Entity;
using Microsoft.AspNetCore.Mvc;
using OOP_Project.ProjectContext;

namespace OOP_Project.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer.CustomerName.Length >= 6 & customer.CustomerCity != "" & customer.CustomerCity.Length >= 3)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Hatalı kullanım!";
                return View();
            }
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            context.Customers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var value = context.Customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
            value.CustomerName = customer.CustomerName;
            value.CustomerCity = customer.CustomerCity;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
