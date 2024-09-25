using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MVCWebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MVCWebApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestViewBag() 
        {
            ViewBag.Teller = 3;
            return View();
        }
        public IActionResult Formulier()
        {
            return View();
            //Deze action verwijst naar onze
            //Views / Test / Formulier.cshtml
        }
        public IActionResult FormulierPost()
        {
            string invoer = Request.Form["TestInvoer"];
            TestModel model = new TestModel();
            model.TestInvoer = invoer;
            return View(model);
            
        }
    }
}
