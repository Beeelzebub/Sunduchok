using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Data;
using Сундучок.Models;
using Сундучок.ViewModels;

namespace Сундучок.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ProductTypeId"] = new SelectList(await _context.ProductTypes.ToListAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;

                if (model.Image != null)
                {
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }
                }

                Picture picture = new Picture { Image = imageData };

                Product product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    ProductTypeId = model.ProductTypeId,
                    Picture = picture
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Management));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            
            if (product == null)
            {
                return NotFound();
            }

            EditProductViewModel model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductTypeId = product.ProductTypeId
            };

            ViewData["ProductTypeId"] = new SelectList(await _context.ProductTypes.ToListAsync(), "Id", "Name", model.ProductTypeId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                Picture picture = null;

                if (model.Image != null)
                {
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }

                    picture = new Picture { Image = imageData };
                }

                var product = await _context.Products.Where(p => p.Id == model.Id).FirstOrDefaultAsync();

                if (picture != null)
                {
                    product.Picture = picture;
                }

                product.Name = model.Name;
                product.Price = model.Price;
                product.ProductTypeId = model.ProductTypeId;
                product.Description = model.Description;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Management));
            }

            ViewData["ProductTypeId"] = new SelectList(await _context.ProductTypes.ToListAsync(), "Id", "Name", model.ProductTypeId);

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Take(12).ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Management()
        {
            var products = await _context.Products
                .Include(p => p.Picture)
                .Include(p => p.ProductType)
                .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Management));
        }
    }
}
