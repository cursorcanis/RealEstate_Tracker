using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Tracker.Data;
using RealEstate_Tracker.Models;

namespace RealEstate_Tracker.Pages.Estates
{
    public class CreateModel : PageModel
    {
        private readonly RealEstate_Tracker.Data.RealEstate_TrackerContext _context;

        public CreateModel(RealEstate_Tracker.Data.RealEstate_TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Estate Estate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Estate == null || Estate == null)
            {
                return Page();
            }

            _context.Estate.Add(Estate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
