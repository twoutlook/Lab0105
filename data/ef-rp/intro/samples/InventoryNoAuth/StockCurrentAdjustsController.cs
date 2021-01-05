using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth
{
    public class StockCurrentAdjustsController : Controller
    {
        private readonly TaiweiContext _context;

        public StockCurrentAdjustsController(TaiweiContext context)
        {
            _context = context;
        }

        // GET: StockCurrentAdjusts
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockCurrentAdjust.ToListAsync());
        }

        // GET: StockCurrentAdjusts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockCurrentAdjust = await _context.StockCurrentAdjust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockCurrentAdjust == null)
            {
                return NotFound();
            }

            return View(stockCurrentAdjust);
        }

        // GET: StockCurrentAdjusts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockCurrentAdjusts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cticketcode,Reason,Cstatus,Createowner,Createtime,Reviewuser,Reviewtime,Lastupdateuser,Lastupdatetime")] StockCurrentAdjust stockCurrentAdjust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockCurrentAdjust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockCurrentAdjust);
        }

        // GET: StockCurrentAdjusts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockCurrentAdjust = await _context.StockCurrentAdjust.FindAsync(id);
            if (stockCurrentAdjust == null)
            {
                return NotFound();
            }
            return View(stockCurrentAdjust);
        }

        // POST: StockCurrentAdjusts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Cticketcode,Reason,Cstatus,Createowner,Createtime,Reviewuser,Reviewtime,Lastupdateuser,Lastupdatetime")] StockCurrentAdjust stockCurrentAdjust)
        {
            if (id != stockCurrentAdjust.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockCurrentAdjust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockCurrentAdjustExists(stockCurrentAdjust.Id))
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
            return View(stockCurrentAdjust);
        }

        // GET: StockCurrentAdjusts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockCurrentAdjust = await _context.StockCurrentAdjust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockCurrentAdjust == null)
            {
                return NotFound();
            }

            return View(stockCurrentAdjust);
        }

        // POST: StockCurrentAdjusts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stockCurrentAdjust = await _context.StockCurrentAdjust.FindAsync(id);
            _context.StockCurrentAdjust.Remove(stockCurrentAdjust);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockCurrentAdjustExists(string id)
        {
            return _context.StockCurrentAdjust.Any(e => e.Id == id);
        }
    }
}
