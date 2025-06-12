using System.Diagnostics;
using CustomerFeedbackPortal.Data;
using CustomerFeedbackPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerFeedbackPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerFeedbackPortalContext _context;

        public HomeController(ILogger<HomeController> logger, CustomerFeedbackPortalContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Ratings()
        {
            var ratings = await _context.Feedback
                .GroupBy(f => f.Rating)
                .Select(g => new
                {
                    Rating = g.Key,
                    Count = g.Count()
                }).ToListAsync();

            var ratingCounts = Enumerable.Range(1, 5)
                .ToDictionary(r => r, r => ratings.FirstOrDefault(x => x.Rating == r)?.Count ?? 0);

            ViewBag.Ratings = ratingCounts;
            return View();
        }
        public IActionResult Pr()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

        

            

    }
}
