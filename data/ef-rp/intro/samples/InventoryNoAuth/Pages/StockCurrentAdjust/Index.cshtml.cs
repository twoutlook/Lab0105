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
    public class IndexModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public IndexModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        public IList<StockCurrentAdjust> StockCurrentAdjust { get;set; }

        public async Task OnGetAsync()
        {
            StockCurrentAdjust = await _context.StockCurrentAdjust.ToListAsync();
        }
    }
}
