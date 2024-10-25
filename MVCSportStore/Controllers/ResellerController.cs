using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCSportStore.Data;
using MVCSportStore.Models;
using MVCSportStore.ViewModels;

namespace MVCSportStore.Controllers
{
    public class ResellerController : Controller
    {
        private readonly StoreDbContext _context;

        public ResellerController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Resellers
        public async Task<IActionResult> Index()
        {
              return _context.Resellers != null ? 
                          View(await _context.Resellers.ToListAsync()) :
                          Problem("Entity set 'StoreDbContext.Resellers'  is null.");
        }

        // GET: Resellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resellers == null)
            {
                return NotFound();
            }

            var reseller = await _context.Resellers
                .FirstOrDefaultAsync(m => m.ResellerId == id);
            if (reseller == null)
            {
                return NotFound();
            }

            return View(reseller);
        }
        [HttpGet]
        // GET: Resellers/Create
        public IActionResult Create()
        {
            var resellers = new Reseller();
            return View(resellers);
        }
        [HttpGet]
        public IActionResult Create2()
        {
            ResellerModel resellers = new ResellerModel();
            resellers.ContentManagementGuid = Guid.NewGuid().ToString();
            return View(resellers);
        }

        // POST: Resellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResellerId,ResellerName,ContentManagementGuid")] Reseller reseller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reseller);
        }
        [HttpPost]
        public IActionResult Create2( ResellerModel reseller)
        {
            if (ModelState.IsValid)
            {
                int resellerId = AddReseller(reseller);
                if(resellerId > -1)
                {
                    AddResellerStock(reseller,resellerId);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reseller);
        }
        // GET: Resellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resellers == null)
            {
                return NotFound();
            }

            var reseller = await _context.Resellers.FindAsync(id);
            if (reseller == null)
            {
                return NotFound();
            }
            return View(reseller);
        }

        // POST: Resellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResellerId,ResellerName,ContentManagementGuid")] Reseller reseller)
        {
            if (id != reseller.ResellerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResellerExists(reseller.ResellerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reseller);
        }

        // GET: Resellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resellers == null)
            {
                return NotFound();
            }

            var reseller = await _context.Resellers
                .FirstOrDefaultAsync(m => m.ResellerId == id);
            if (reseller == null)
            {
                return NotFound();
            }

            return View(reseller);
        }

        // POST: Resellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resellers == null)
            {
                return Problem("Entity set 'StoreDbContext.Resellers'  is null.");
            }
            var reseller = await _context.Resellers.FindAsync(id);
            if (reseller != null)
            {
                _context.Resellers.Remove(reseller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResellerExists(int id)
        {
          return (_context.Resellers?.Any(e => e.ResellerId == id)).GetValueOrDefault();
        }
        private bool AddResellerStock(ResellerModel reseller ,int resellerId) 
        {
            bool succeeded = false;
            try
            {
                ResellerStock rs = new ResellerStock();
                rs.Amount = reseller.Amount;
                rs.ResellerId = resellerId;
                rs.ProductId = reseller.ProductId;
                _context.ResellerStocks.Add(rs);
                _context.SaveChanges();
                return succeeded = true;

            }
            catch (Exception)
            {
                return succeeded;
                throw;
            }
        }
        private int AddReseller(ResellerModel reseller)
        {
            int id = -1;
            try
            {
                Reseller r = new Reseller();
                r.ResellerName = reseller.ResellerName;
                r.ContentManagementGuid = reseller.ContentManagementGuid;
                _context.Resellers.Add(r);
                _context.SaveChanges();
                return r.ResellerId;
            }
            catch (Exception)
            {
               return id;
                throw;
            }
           
        }
    }
}
