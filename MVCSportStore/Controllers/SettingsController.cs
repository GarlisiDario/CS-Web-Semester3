using Microsoft.AspNetCore.Mvc;
using MVCSportStore.ViewModels;

namespace MVCSportStore.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PagingSettingsView()
        {
            PagingSettingViewModel paging = new PagingSettingViewModel();
            paging.ProductPagination = PagingSettings.ProductPagination;
            return View(paging);
        }
        [HttpPost]
        public IActionResult PagingSettingsView(PagingSettingViewModel paging)
        {
            PagingSettings.ProductPagination = paging.ProductPagination;
            return RedirectToAction("Index", "Home");
        }
    }
}
