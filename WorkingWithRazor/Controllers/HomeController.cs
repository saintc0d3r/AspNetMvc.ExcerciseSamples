using System.Web.Mvc;

using WorkingWithRazor.Models;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        private Product _product =
            new Product { ProductID = 1, Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275M };
        
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(_product);
        }


        public ActionResult NameAndPrice()
        {
            return View(_product); 
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(_product);
        }

        public ActionResult DemoArray()
        {
            Product[] products = new Product[] { 
                new Product {Name="Kayak", Price=275M},
                new Product {Name="LifeJacket", Price=48.95M},
                new Product {Name="Socker Ball", Price =19.50M}
            };
            return View(products);
        }
    }
}
