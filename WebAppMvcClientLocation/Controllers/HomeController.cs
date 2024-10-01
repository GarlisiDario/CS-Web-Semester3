using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMvcClientLocation.Models;
using WebAppMvcClientLocation.Data;

namespace WebAppMvcClientLocation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            DataBase.StartDataBase();
            ViewBag.Client = DataBase.Clients.Count;
            ViewBag.Locatie = DataBase.Locations.Count;
            Console.WriteLine(DataBase.Clients.Count);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
