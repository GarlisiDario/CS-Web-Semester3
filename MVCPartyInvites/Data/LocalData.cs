using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Data
{
    public class LocalData : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public static List<Gast> GastList = new List<Gast>();
        public LocalData() 
        {
        }
    }
}
