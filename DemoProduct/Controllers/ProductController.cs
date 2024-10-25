using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;

namespace DemoProduct.Controllers
{
    public class ProductController : Controller
    {
        // IProductDal karşılayacak değer olarak "new EfProductDal()" yazılır. 
        ProductManager _productManager = new ProductManager(new EfProductDal());

        public IActionResult Index()
        {
            var values = _productManager.TGetList();
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
            ModelState.Clear();
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(product);
            if (results.IsValid)
            {
                _productManager.TInsert(product);
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

        public IActionResult DeleteProduct(int id)
        {
            var value = _productManager.TGetById(id);
            _productManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _productManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productManager.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
