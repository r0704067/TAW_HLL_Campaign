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
    public class BuildingTypesController : Controller
    {
        private readonly CampaignContext _context;

        public BuildingTypesController(CampaignContext context)
        {
            _context = context;
        }

        // GET: Admin/BuildingTypes
        public async Task<IActionResult> Index()
        {
              return _context.BuildingTypes != null ? 
                          View(await _context.BuildingTypes.ToListAsync()) :
                          Problem("Entity set 'CampaignContext.BuildingTypes'  is null.");
        }

        // GET: Admin/BuildingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .FirstOrDefaultAsync(m => m.BuildingTypeID == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingTypeID,Name,Tier,Cost,Income,Discription")] BuildingType buildingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType == null)
            {
                return NotFound();
            }
            return View(buildingType);
        }

        // POST: Admin/BuildingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingTypeID,Name,Tier,Cost,Income,Discription")] BuildingType buildingType)
        {
            if (id != buildingType.BuildingTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingTypeExists(buildingType.BuildingTypeID))
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
            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .FirstOrDefaultAsync(m => m.BuildingTypeID == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // POST: Admin/BuildingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuildingTypes == null)
            {
                return Problem("Entity set 'CampaignContext.BuildingTypes'  is null.");
            }
            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType != null)
            {
                _context.BuildingTypes.Remove(buildingType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingTypeExists(int id)
        {
          return (_context.BuildingTypes?.Any(e => e.BuildingTypeID == id)).GetValueOrDefault();
        }
    }
}
