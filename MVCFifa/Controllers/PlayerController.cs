using Microsoft.AspNetCore.Mvc;
using MVCFifa.Data;
using MVCFifa.Models;

namespace MVCFifa.Controllers
{
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
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
        private void AddPlayer(Player player) 
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
    }

}
