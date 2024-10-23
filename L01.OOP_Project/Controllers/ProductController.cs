using OOP_Project.Entity;
using Microsoft.AspNetCore.Mvc;
using OOP_Project.ProjectContext;

namespace OOP_Project.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            value.ProductName = product.ProductName;
            value.ProductPrice = product.ProductPrice;
            value.ProductStock = product.ProductStock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
