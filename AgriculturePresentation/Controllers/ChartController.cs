using Microsoft.AspNetCore.Mvc;
using Agriculture.Presentation.Models;

namespace Agriculture.Presentation.Controllers
{
    public class ChartController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            List<ProductClass> products = new List<ProductClass>();
            products.Add(new ProductClass
            {
                productname = "Buğday",
                productvalue = 850
            });

            products.Add(new ProductClass
            {
                productname = "Mercimek",
                productvalue = 480
            });

            products.Add(new ProductClass
            {
                productname = "Arpa",
                productvalue = 250
            });

            products.Add(new ProductClass
            {
                productname = "Pirinç",
                productvalue = 120
            });

            products.Add(new ProductClass
            {
                productname = "Domates",
                productvalue = 960
            });

            return Json(new { jsonList = products });
        }
    }
}
