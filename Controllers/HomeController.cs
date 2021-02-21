using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Data;
using Сундучок.Models;
using PagedList.Mvc;
using PagedList;
using Сундучок.ViewModels;

namespace Сундучок.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? p)
        {
            var products = await _context.Products
                .Include(p => p.Picture)
                .ToListAsync();

            int currentPage = p ?? 1;

            AssortmentViewModel model = new AssortmentViewModel
            {
                TotalPages = (int)((products.Count / 10)),
                CurrentPage = currentPage,
                Products = products.Skip(10 * (currentPage - 1)).Take(10).ToList()
            };

            return View(model);
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
