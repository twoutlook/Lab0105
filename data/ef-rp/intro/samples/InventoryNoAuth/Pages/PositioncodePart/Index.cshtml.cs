using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;

namespace InventoryNoAuth.Pages.PositioncodePart
{
    public class IndexModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public IndexModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }

        public IList<MCpositioncodePart> MCpositioncodePart { get;set; }

        public async Task OnGetAsync(string cpositioncode)
        {
      //      Console.WriteLine("what is cpositioncode" + cpositioncode);
            System.Diagnostics.Debug.WriteLine("what is cpositioncode" + cpositioncode);
            MCpositioncodePart = await _context.MCpositioncodePart.Where(x=>x.Cpositioncode == cpositioncode).OrderBy(x=>x.Cinvcode).ToListAsync();
        }
    }
}
