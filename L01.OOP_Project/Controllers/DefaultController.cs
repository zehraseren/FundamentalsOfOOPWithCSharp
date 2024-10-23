using Microsoft.AspNetCore.Mvc;
using OOP_Project.Examples;

namespace OOP_Project.Controllers
{
    public class DefaultController : Controller
    {
        /*
         * Class'ların içinde öğelere erişim sağlamak için bir method'un içinde erişim sağlanması istenen class'tan bir nesne türetilir.
         * ClassName objectName = new ClassName();
         */

        //void Operations()
        //{
        //    Class1 c = new Class1();
        //    c.Sum();
        //}

        void Messages()
        {
            ViewBag.m1 = "Merhaba bu bir Core projesidir.";
            ViewBag.m2 = "Merhaba proje çok iyi duruyor.";
            ViewBag.m3 = "Selamlar hi hello bonjour";
        }

        int Sum1()
        {
            int n1 = 20;
            int n2 = 30;
            int r1 = n1 + n2;
            return r1;
        }

        int Circumference()
        {
            int shortEdge = 10;
            int longEdge = 20;
            int c = 2 * (shortEdge + longEdge);
            return c;
        }

        // Homework
        int Factoriel()
        {
            int fa = 1;
            for (int i = 1; i <= 5; i++)
            {
                fa *= i;
            }
            return fa;
        }

        string Sentence()
        {
            string s = "Cumhuriyetimizin 101. yılı kutlu olsun!";
            return s;
        }

        void MessageList(string p)
        {
            ViewBag.v = p;
        }

        void User(string username)
        {
            ViewBag.u = username;
        }

        int Sum(int n1, int n2)
        {
            int result = n1 + n2;
            return result;
        }

        int Factoriel(int p)
        {
            int f = 1;
            for (int i = 1; i <= p; i++)
            {
                f *= i;
            }
            return f;
        }

        public IActionResult Index()
        {
            Messages();
            MessageList("Selam!");
            User("zehraseren");
            ViewBag.sum = Sum(6, 7);
            return View();
        }

        public IActionResult Products()
        {
            Messages();
            ViewBag.s = Sum1();
            ViewBag.c = Circumference();
            ViewBag.f = Factoriel();
            ViewBag.factor = Factoriel(6);
            User("fzseren");
            return View();
        }

        public IActionResult Customer()
        {
            ViewBag.s = Sentence();
            User("admin004");
            return View();
        }

        public IActionResult Test()
        {
            Cities city = new Cities();

            city.CityId = 1;
            city.CityName = "Kiev";
            city.Population = 1000000;
            city.Country = "Ukrayna";
            city.Color1 = "Mavi";
            city.Color2 = "Sarı";

            ViewBag.c11 = city.CityId;
            ViewBag.c12 = city.CityName;
            ViewBag.c13 = city.Country;
            ViewBag.c14 = city.Population;
            ViewBag.c15 = city.Color1;
            ViewBag.c16 = city.Color2;

            city.CityId = 2;
            city.CityName = "Üsküp";
            city.Population = 500000;
            city.Country = "Makedonya";
            city.Color1 = "Kırmızı";
            city.Color2 = "Sarı";

            ViewBag.c21 = city.CityId;
            ViewBag.c22 = city.CityName;
            ViewBag.c23 = city.Country;
            ViewBag.c24 = city.Population;
            ViewBag.c25 = city.Color1;
            ViewBag.c26 = city.Color2;

            return View();
        }
    }
}
