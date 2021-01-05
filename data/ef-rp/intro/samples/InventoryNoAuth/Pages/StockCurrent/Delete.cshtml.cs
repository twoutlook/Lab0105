using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth.Pages.StockCurrent
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public DeleteModel(InventoryNoAuth.Data.TaiweiContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockCurrent = await _context.StockCurrent.FindAsync(id);

            if (StockCurrent != null)
            {
                _context.StockCurrent.Remove(StockCurrent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
