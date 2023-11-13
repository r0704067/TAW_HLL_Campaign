using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAW_HLL_Campaign.Data;
using TAW_HLL_Campaign.Models;

namespace TAW_HLL_Campaign.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GamesController : Controller
    {
        private readonly CampaignContext _context;
        public GamesController(CampaignContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Assuming the Game model has a property called "Status" to represent the game state
            var lastGame = await _context.Games.OrderByDescending(g => g.GameId).FirstOrDefaultAsync();

            if (lastGame != null)
            {
                if (lastGame.Status == Status.Active)
                {
                    // If the last game is active, redirect to another view
                    return RedirectToAction("ActiveGameView");
                }
            }

            // If there's no active game, or if the last game is not active, show the default Index view
            return View();
        }
        // GET: Admin/Game/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameID,Name,Status")] Game game)
        {
            
            return View(game);
        }
    }
}
