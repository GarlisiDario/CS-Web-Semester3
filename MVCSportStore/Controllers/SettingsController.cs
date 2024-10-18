using Microsoft.AspNetCore.Mvc;

namespace MVCSportStore.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
