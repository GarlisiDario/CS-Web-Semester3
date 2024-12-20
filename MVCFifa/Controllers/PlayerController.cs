﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCFifa.Data;
using MVCFifa.Models;
using MVCFifa.ViewModel;

namespace MVCFifa.Controllers
{
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
           
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
        [HttpGet]
        public IActionResult Create2()
        {
            var newPlayer = new NewPlayer();
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return View(newPlayer);
        }
        [HttpPost]
        public IActionResult Create2(NewPlayer newPlayer)
        {
            if (ModelState.IsValid)
            {
                AddNewPlayer(newPlayer);
                return RedirectToAction("Index");
            }
            return View(newPlayer);
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
        private void AddNewPlayer(NewPlayer newPlayer)
        {
            Player p = new Player();
            p.FirstName = newPlayer.FirstName;
            p.LastName = newPlayer.LastName;
            p.ImageLink = newPlayer.ImageLink;
            _context.Players.Add(p);
            _context.SaveChanges();

            var tp = new TeamPlayer();
            
        }
    }

}
