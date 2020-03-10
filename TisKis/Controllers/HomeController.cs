using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TisKis.Data;
using TisKis.Models;
using TisKis.ViewModels;

namespace TisKis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var history = new List<UserHistory>();
            if (User.Identity.IsAuthenticated)
            {
                history = await dbContext.UserHistories
                    .Include(u => u.User)
                    .Include(ci => ci.ConvertedImage)
                    .Include(ui => ui.UploadImage)
                    .Where(h => h.User.UserName.Equals(User.Identity.Name))
                    .ToListAsync();
            }
            return View(history);
        }

        public IActionResult Privacy()
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
