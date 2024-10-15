using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;
using MVCSportStore.ViewModels;
using System.Diagnostics;

namespace MVCSportStore.Controllers
{
    public class HomeController : Controller
    {
        StoreDbContext _context;
        private ProductRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,StoreDbContext context)
        {
            _logger = logger;
            _context = context;
            _repo = new ProductRepository(_context);
        }

        public IActionResult Index(int id = 1)
        {
            var productModel = _repo.GetProductModel(id);
            return View(productModel);
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
