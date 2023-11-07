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
    public class ManeuversController : Controller
    {
        private readonly CampaignContext _context;

        public ManeuversController(CampaignContext context)
        {
            _context = context;
        }

        // GET: Admin/Maneuvers
        public async Task<IActionResult> Index()
        {
              return _context.Maneuvers != null ? 
                          View(await _context.Maneuvers.ToListAsync()) :
                          Problem("Entity set 'CampaignContext.Maneuvers'  is null.");
        }

        // GET: Admin/Maneuvers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maneuvers == null)
            {
                return NotFound();
            }

            var maneuver = await _context.Maneuvers
                .FirstOrDefaultAsync(m => m.maneuverId == id);
            if (maneuver == null)
            {
                return NotFound();
            }

            return View(maneuver);
        }

        // GET: Admin/Maneuvers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Maneuvers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maneuverId,Name,Cost,Discription,BuildingID,RoadID")] Maneuver maneuver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maneuver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maneuver);
        }

        // GET: Admin/Maneuvers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maneuvers == null)
            {
                return NotFound();
            }

            var maneuver = await _context.Maneuvers.FindAsync(id);
            if (maneuver == null)
            {
                return NotFound();
            }
            return View(maneuver);
        }

        // POST: Admin/Maneuvers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("maneuverId,Name,Cost,Discription,BuildingID,RoadID")] Maneuver maneuver)
        {
            if (id != maneuver.maneuverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maneuver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManeuverExists(maneuver.maneuverId))
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
            return View(maneuver);
        }

        // GET: Admin/Maneuvers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maneuvers == null)
            {
                return NotFound();
            }

            var maneuver = await _context.Maneuvers
                .FirstOrDefaultAsync(m => m.maneuverId == id);
            if (maneuver == null)
            {
                return NotFound();
            }

            return View(maneuver);
        }

        // POST: Admin/Maneuvers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maneuvers == null)
            {
                return Problem("Entity set 'CampaignContext.Maneuvers'  is null.");
            }
            var maneuver = await _context.Maneuvers.FindAsync(id);
            if (maneuver != null)
            {
                _context.Maneuvers.Remove(maneuver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManeuverExists(int id)
        {
          return (_context.Maneuvers?.Any(e => e.maneuverId == id)).GetValueOrDefault();
        }
    }
}
