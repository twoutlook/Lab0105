using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public DeleteModel(InventoryNoAuth.Data.TaiweiContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockCurrentAdjust = await _context.StockCurrentAdjust.FindAsync(id);

            if (StockCurrentAdjust != null)
            {
                _context.StockCurrentAdjust.Remove(StockCurrentAdjust);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
