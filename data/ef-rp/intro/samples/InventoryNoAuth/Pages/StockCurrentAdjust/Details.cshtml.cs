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
    public class DetailsModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public DetailsModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

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
    }
}
