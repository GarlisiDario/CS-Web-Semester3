using Microsoft.AspNetCore.Mvc;
using WebAppMvcClientLocation.Data;
using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Data.DataBase.Clients);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var client = new Client();
            return View(client); 
        }
        [HttpPost]
        public IActionResult Create(Client c) 
        {
            if (ModelState.IsValid) 
            {
                DataBase.Clients.Add(c);
                return RedirectToAction("Index");
            }
            
            return View(c);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            var loc = new Location();
            return View(loc);
        }
        [HttpPost]
        public IActionResult CreateLocation(Location l)
        {
            if (ModelState.IsValid)
            {
                DataBase.Locations.Add(l);
                return RedirectToAction("Index");
            }

            return View(l);
        }

    }
}
