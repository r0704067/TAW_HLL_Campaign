using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAW_HLL_Campaign.Data;
using TAW_HLL_Campaign.Models.ViewModels;

namespace TAW_HLL_Campaign.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalculatorController : Controller
    {
        private readonly CampaignContext _context;

        public CalculatorController(CampaignContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CalculatorViewModel
            {
                Teams = await _context.Teams
            .Include(t => t.Stockpile)
            .ToListAsync(),
                Sectors = await _context.Sectors
            .Include(s => s.Team)
            .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Generate()
        {
            var teams = _context.Teams.Include(t => t.Stockpile).ToList();

            foreach (var team in teams)
            {
                // Calculate the sum of supplies for the current team's sectors
                var suppliesSum = _context.Sectors
                    .Where(s => s.TeamID == team.TeamID)
                    .Sum(s => s.SuppliesIncome);

                // Add the calculated sum to the team's Stockpile.TotalSupplies
                team.Stockpile.TotalSupplies += suppliesSum;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
            
        }

    }
}
