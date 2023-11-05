using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace TAW_HLL_Campaign.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class MaintainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
