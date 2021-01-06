using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth.Pages.FullpartList
{
    public class DetailsModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public DetailsModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        public MFullpartList MFullpartList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MFullpartList = await _context.MFullpartList.FirstOrDefaultAsync(m => m.Fullpart == id);

            if (MFullpartList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
