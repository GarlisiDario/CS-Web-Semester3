using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext _context;
        public ProductController(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var product = new Product(); 
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                AddProduct(product);
                return RedirectToAction("Index","Home");

            }
            return View(product);
        }
        private void AddProduct(Product product) 
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        
    }
}
