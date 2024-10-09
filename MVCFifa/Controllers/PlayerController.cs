using Microsoft.AspNetCore.Mvc;
using MVCFifa.Data;
using MVCFifa.Models;

namespace MVCFifa.Controllers
{
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _environment = environment;
        }
        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var player = new Player();

            return View(player);
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }
        public IActionResult Details(int id) 
        {
            var player = _context.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            var fileExist = false;
            if (player.ImageLink != null ) 
            {
                var path = _environment.WebRootPath;
                var file = Path.Combine($"{path}\\images",player.ImageLink);
                fileExist = System.IO.File.Exists(file);
                
            }
            ViewBag.FileExist = fileExist;
            return View(player);
        }
        private void AddPlayer(Player player) 
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
    }

}
