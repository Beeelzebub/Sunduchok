﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Data;
using Сундучок.Models;

namespace Сундучок.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> MyHistory()
        {
            var orders = await _context.Orders
                .Where(o => o.CustomerId == _userManager.GetUserId(User))
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> AllHistory()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .ToListAsync();

            return View(orders);
        }
    }
}
