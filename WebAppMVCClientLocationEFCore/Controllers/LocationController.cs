using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocationEFCore.Models;
using WebAppMVCClientLocationEFCore.Data;

namespace WebAppMVCClientLocationEFCore.Controllers
{
    public class LocationController : Controller
    {
        ClientLocationContext _context;
        public LocationController(ClientLocationContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var locations = _context.Locations;
            return View(locations);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var locaction = new Location();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                AddLocation(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var location = _context.Locations.Where(x => x.LocationId.Equals(id)).FirstOrDefault();
            return View(location);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var location = _context.Locations.Where(x => x.LocationId.Equals(id)).FirstOrDefault();
            return View(location);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var location = _context.Locations.Where(x => x.LocationId.Equals(id)).FirstOrDefault();
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = _context.Locations.Where(x => x.LocationId.Equals(id)).FirstOrDefault();
            return View(location);
        }
        [HttpPost]
        public IActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                UpdateLocation(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }
        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }
        
        public void AddLocation(Location location) 
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }
    }
}
