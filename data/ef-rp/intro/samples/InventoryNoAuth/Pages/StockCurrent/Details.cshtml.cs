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
    public class DetailsModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public DetailsModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

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
    }
}
