using Microsoft.AspNetCore.Mvc;

namespace MvcTestEFCore.Controllers
{
    public class FirstTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
