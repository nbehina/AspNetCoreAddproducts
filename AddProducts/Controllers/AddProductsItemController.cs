using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddProducts.Data;
using AddProducts.Models;

namespace AddProducts.Controllers
{
    public class AddProductsItemController : Controller
    {
        private readonly AddProductsContext _context;

        public AddProductsItemController(AddProductsContext context)
        {
            _context = context;
        }

        // GET: AddProductsItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddProductsItem.ToListAsync());
        }

        // GET: AddProductsItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AddProductsItem = await _context.AddProductsItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (AddProductsItem == null)
            {
                return NotFound();
            }

            return View(AddProductsItem);
        }

        // GET: AddProductsItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddProductsItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price")] AddProductsItem AddProductsItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(AddProductsItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(AddProductsItem);
        }

        // GET: AddProductsItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AddProductsItem = await _context.AddProductsItem.FindAsync(id);
            if (AddProductsItem == null)
            {
                return NotFound();
            }
            return View(AddProductsItem);
        }

        // POST: AddProductsItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price")] AddProductsItem AddProductsItem)
        {
            if (id != AddProductsItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(AddProductsItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddProductsItemExists(AddProductsItem.Id))
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
            return View(AddProductsItem);
        }

        // GET: AddProductsItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AddProductsItem = await _context.AddProductsItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (AddProductsItem == null)
            {
                return NotFound();
            }

            return View(AddProductsItem);
        }

        // POST: AddProductsItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var AddProductsItem = await _context.AddProductsItem.FindAsync(id);
            _context.AddProductsItem.Remove(AddProductsItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddProductsItemExists(int id)
        {
            return _context.AddProductsItem.Any(e => e.Id == id);
        }
    }
}



