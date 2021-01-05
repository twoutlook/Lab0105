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

namespace InventoryNoAuth.Pages.StockCurrent
{
    public class EditModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public EditModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventoryNoAuth.Models.StockCurrent StockCurrent { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockCurrent = await _context.StockCurrent.FirstOrDefaultAsync(m => m.Id == id);

            if (StockCurrent == null)
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

            _context.Attach(StockCurrent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockCurrentExists(StockCurrent.Id))
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

        private bool StockCurrentExists(string id)
        {
            return _context.StockCurrent.Any(e => e.Id == id);
        }
    }
}
