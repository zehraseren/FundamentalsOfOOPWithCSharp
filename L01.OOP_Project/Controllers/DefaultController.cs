using Microsoft.AspNetCore.Mvc;

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
    }
}
