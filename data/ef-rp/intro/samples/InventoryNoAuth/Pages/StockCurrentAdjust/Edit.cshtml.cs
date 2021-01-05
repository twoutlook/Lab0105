using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth
{
    public class EditModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public EditModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StockCurrentAdjust StockCurrentAdjust { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockCurrentAdjust = await _context.StockCurrentAdjust.FirstOrDefaultAsync(m => m.Id == id);

            if (StockCurrentAdjust == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StockCurrentAdjust).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockCurrentAdjustExists(StockCurrentAdjust.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StockCurrentAdjustExists(string id)
        {
            return _context.StockCurrentAdjust.Any(e => e.Id == id);
        }
    }
}
