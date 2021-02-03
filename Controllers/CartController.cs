﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Data;
using Сундучок.Models;
using Сундучок.ViewModels;

namespace Сундучок.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");

            return View(cart);
        }

        [Authorize]
        public IActionResult Delivery()
        {
            Address address = HttpContext.Session.Get<Address>("address");

            if (address != null)
            {
                DelivaryViewModel model = new DelivaryViewModel
                {
                    Hous = address.Hous,
                    Apartment = address.Apartment,
                    City = address.City,
                    PhoneNumber = address.PhoneNumber,
                    Porch = address.Porch,
                    Street = address.Street
                };

                return View(model);
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delivery(DelivaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address
                {
                    Hous = model.Hous,
                    Apartment = model.Apartment,
                    City = model.City,
                    PhoneNumber = model.PhoneNumber,
                    Porch = model.Porch,
                    Street = model.Street
                };

                HttpContext.Session.Set<Address>("address", address);

                return View("Pay");
                
            }

            return View(model);
        }

        public IActionResult Add(int Id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();

            Product product = _context.Products.Where(g => g.Id == Id).Include(p => p.Picture).FirstOrDefault();

            if (product != null)
            {
                cart.AddItem(product);
                HttpContext.Session.Set<Cart>("cart", cart);

                return PartialView(true);
            }

            return PartialView(false);
        }

        public IActionResult Remove(int Id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();

            Product product = _context.Products.Where(g => g.Id == Id).FirstOrDefault();

            if (product != null)
            {
                cart.RemoveItem(product);

                if (cart.Lines().Count() == 0)
                {
                    cart = null;
                }
                HttpContext.Session.Set<Cart>("cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}