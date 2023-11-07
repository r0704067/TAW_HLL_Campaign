using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAW_HLL_Campaign.Data;
using TAW_HLL_Campaign.Models;

namespace TAW_HLL_Campaign.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectorsController : Controller
    {
        private readonly CampaignContext _context;

        public SectorsController(CampaignContext context)
        {
            _context = context;
        }

        // GET: Admin/Sectors
        public async Task<IActionResult> Index()
        {
              return _context.Sectors != null ? 
                          View(await _context.Sectors.Include(s => s.Team).ToListAsync()) :
                          Problem("Entity set 'CampaignContext.Sectors'  is null.");
        }

        // GET: Admin/Sectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors
                .Include(s => s.Team)
                .FirstOrDefaultAsync(m => m.SectorId == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Admin/Sectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectorId,Name,SuppliesIncome,VictoryPoints,BuildSlots,TeamID")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }

        // GET: Admin/Sectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }
            ViewBag.TeamID = new SelectList(_context.Teams, "TeamID", "Name", sector.TeamID);
            return View(sector);
        }

        // POST: Admin/Sectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectorId,Name,SuppliesIncome,VictoryPoints,BuildSlots,TeamID")] Sector sector)
        {
            if (id != sector.SectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.SectorId))
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
            ViewBag.TeamID = new SelectList(_context.Teams, "TeamID", "Name", sector.TeamID);

            return View(sector);
        }

        // GET: Admin/Sectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors
                .FirstOrDefaultAsync(m => m.SectorId == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Admin/Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sectors == null)
            {
                return Problem("Entity set 'CampaignContext.Sectors'  is null.");
            }
            var sector = await _context.Sectors.FindAsync(id);
            if (sector != null)
            {
                _context.Sectors.Remove(sector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorExists(int id)
        {
          return (_context.Sectors?.Any(e => e.SectorId == id)).GetValueOrDefault();
        }
    }
}
