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
    public class RoadsController : Controller
    {
        private readonly CampaignContext _context;

        public RoadsController(CampaignContext context)
        {
            _context = context;
        }

        // GET: Admin/Roads
        public async Task<IActionResult> Index()
        {
              return _context.Roads != null ? 
                          View(await _context.Roads.ToListAsync()) :
                          Problem("Entity set 'CampaignContext.Roads'  is null.");
        }

        // GET: Admin/Roads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Roads == null)
            {
                return NotFound();
            }

            var road = await _context.Roads
                .FirstOrDefaultAsync(m => m.RoadID == id);
            if (road == null)
            {
                return NotFound();
            }

            return View(road);
        }

        // GET: Admin/Roads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoadID,Name,StartSectorID,EndSectorID")] Road road)
        {
            if (ModelState.IsValid)
            {
                _context.Add(road);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(road);
        }

        // GET: Admin/Roads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Roads == null)
            {
                return NotFound();
            }

            var road = await _context.Roads.FindAsync(id);
            if (road == null)
            {
                return NotFound();
            }
            return View(road);
        }

        // POST: Admin/Roads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoadID,Name,StartSectorID,EndSectorID")] Road road)
        {
            if (id != road.RoadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(road);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoadExists(road.RoadID))
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
            return View(road);
        }

        // GET: Admin/Roads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roads == null)
            {
                return NotFound();
            }

            var road = await _context.Roads
                .FirstOrDefaultAsync(m => m.RoadID == id);
            if (road == null)
            {
                return NotFound();
            }

            return View(road);
        }

        // POST: Admin/Roads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Roads == null)
            {
                return Problem("Entity set 'CampaignContext.Roads'  is null.");
            }
            var road = await _context.Roads.FindAsync(id);
            if (road != null)
            {
                _context.Roads.Remove(road);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoadExists(int id)
        {
          return (_context.Roads?.Any(e => e.RoadID == id)).GetValueOrDefault();
        }
    }
}
