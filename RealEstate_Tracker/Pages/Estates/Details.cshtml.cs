using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate_Tracker.Data;
using RealEstate_Tracker.Models;

namespace RealEstate_Tracker.Pages.Estates
{
    public class DetailsModel : PageModel
    {
        private readonly RealEstate_Tracker.Data.RealEstate_TrackerContext _context;

        public DetailsModel(RealEstate_Tracker.Data.RealEstate_TrackerContext context)
        {
            _context = context;
        }

      public Estate Estate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estate == null)
            {
                return NotFound();
            }

            var estate = await _context.Estate.FirstOrDefaultAsync(m => m.Id == id);
            if (estate == null)
            {
                return NotFound();
            }
            else 
            {
                Estate = estate;
            }
            return Page();
        }
    }
}
