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
    public class DefencesController : Controller
    {
        private readonly CampaignContext _context;

        public DefencesController(CampaignContext context)
        {
            _context = context;
        }

        // GET: Admin/Defences
        public async Task<IActionResult> Index()
        {
              return _context.Defence != null ? 
                          View(await _context.Defence.ToListAsync()) :
                          Problem("Entity set 'CampaignContext.Defence'  is null.");
        }

        // GET: Admin/Defences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Defence == null)
            {
                return NotFound();
            }

            var defence = await _context.Defence
                .FirstOrDefaultAsync(m => m.DefenceID == id);
            if (defence == null)
            {
                return NotFound();
            }

            return View(defence);
        }

        // GET: Admin/Defences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Defences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefenceID,Name,Description")] Defence defence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defence);
        }

        // GET: Admin/Defences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Defence == null)
            {
                return NotFound();
            }

            var defence = await _context.Defence.FindAsync(id);
            if (defence == null)
            {
                return NotFound();
            }
            return View(defence);
        }

        // POST: Admin/Defences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefenceID,Name,Description")] Defence defence)
        {
            if (id != defence.DefenceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefenceExists(defence.DefenceID))
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
            return View(defence);
        }

        // GET: Admin/Defences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Defence == null)
            {
                return NotFound();
            }

            var defence = await _context.Defence
                .FirstOrDefaultAsync(m => m.DefenceID == id);
            if (defence == null)
            {
                return NotFound();
            }

            return View(defence);
        }

        // POST: Admin/Defences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Defence == null)
            {
                return Problem("Entity set 'CampaignContext.Defence'  is null.");
            }
            var defence = await _context.Defence.FindAsync(id);
            if (defence != null)
            {
                _context.Defence.Remove(defence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefenceExists(int id)
        {
          return (_context.Defence?.Any(e => e.DefenceID == id)).GetValueOrDefault();
        }
    }
}
