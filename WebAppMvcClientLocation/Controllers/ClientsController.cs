using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create() { return View(); }
        [HttpPost]
        public IActionResult Create(Client c) 
        {
            string userid = Request.Form["clientId"];
            string locationId = Request.Form["locId"];
            string clientName = Request.Form["clientName"];
            c.ClientId = int.Parse(userid);
            c.ClientName = clientName;
            c.LocatieId = int.Parse(locationId);
            var r = Data.DataBase.AddClient(c);
            if (r.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
