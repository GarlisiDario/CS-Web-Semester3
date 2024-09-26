using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Data;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Controllers
{
    public class GastController : Controller
    {
        public IActionResult Index()
        {
            Gast g = new Gast();
            return View(g);
        }
        [HttpPost]
        public IActionResult Reservatie(Gast g) 
        {
            LocalData.GastList.Add(g);
            return RedirectToAction("Index","Home");
        }

    }
}
