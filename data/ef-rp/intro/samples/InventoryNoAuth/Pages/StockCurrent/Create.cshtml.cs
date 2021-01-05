using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth.Pages.StockCurrent
{
    public class CreateModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public CreateModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InventoryNoAuth.Models.StockCurrent StockCurrent { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StockCurrent.Add(StockCurrent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
