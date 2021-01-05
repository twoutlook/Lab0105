using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryNoAuth.Data;
using InventoryNoAuth.Models;
using ContosoUniversity;

namespace InventoryNoAuth
{
    public class MCpositioncodeModel : PageModel
    {
        private readonly InventoryNoAuth.Data.TaiweiContext _context;

        public MCpositioncodeModel(InventoryNoAuth.Data.TaiweiContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        //    public IList<MCpoisitioncode> MCpoisitioncode { get;set; }
        public PaginatedList<MCpoisitioncode> MCpoisitioncode { get; set; }
        public async Task OnGetAsync(string sortOrder,
       string currentFilter, string searchString, int? pageIndex)
        {

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            //  MCpoisitioncode = await _context.MCpoisitioncode.ToListAsync();

            IQueryable<MCpoisitioncode> studentsIQ = from s in _context.MCpoisitioncode
                                                     select s;

            //IQueryable<Student> studentsIQ = from s in _context.Students
            //                                 select s;
            int pageSize = 10;
            MCpoisitioncode = await PaginatedList<MCpoisitioncode>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
