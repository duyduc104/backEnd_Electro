using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using electroMVC.Data;
using electroMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace electroMVC.Controllers
{
	public class ProductsController : Controller
    {
        private readonly electroMVCContext _context;

        public ProductsController(electroMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var products = from m in _context.Product
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName!.Contains(searchString));
            }
            var electroMVCContext = _context.Product.Include(p => p.Category).Include(p => p.brand);
            return View(await products.ToListAsync());
        }

		public async Task<IActionResult> ProductByCategory(int catId)
		{
			
			var electroMVCContext = _context.Product.Include(p => p.Category).Include(p => p.brand).Where(p=>p.CategoryId == catId);
			return View(await electroMVCContext.ToListAsync());
		}

		public async Task<IActionResult> DescriptionAndBuy(int productId)
		{

			var electroMVCContext = _context.Product.Include(p => p.Category).Include(p => p.brand).Where(p => p.ProductId == productId);
			return View(await electroMVCContext.ToListAsync());
		}
		public async Task<IActionResult> CheckOut(int productId)
		{

			var electroMVCContext = _context.Product.Include(p => p.Category).Include(p => p.brand).Where(p => p.ProductId == productId);
			return View(await electroMVCContext.ToListAsync());
		}

		public async Task<IActionResult> ShowProduct(int productId)
		{

			var electroMVCContext = _context.Product.Include(p => p.Category).Include(p => p.brand).Where(p => p.ProductId == productId);
			return View(await electroMVCContext.ToListAsync());
		}
		[Authorize(Roles = "admin")]
		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.brand)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

		[Authorize(Roles = "admin")]
		// GET: Products/Create
		public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,ProductImage,ProductPrice,ProductQuantity,CategoryId,BrandId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

		[Authorize(Roles = "admin")]
		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,ProductImage,ProductPrice,ProductQuantity,CategoryId,BrandId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

		[Authorize(Roles = "admin")]
		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.brand)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
		
	}
}
