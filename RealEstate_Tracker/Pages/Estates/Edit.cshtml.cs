﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate_Tracker.Data;
using RealEstate_Tracker.Models;

namespace RealEstate_Tracker.Pages.Estates
{
    public class EditModel : PageModel
    {
        private readonly RealEstate_Tracker.Data.RealEstate_TrackerContext _context;

        public EditModel(RealEstate_Tracker.Data.RealEstate_TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estate Estate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estate == null)
            {
                return NotFound();
            }

            var estate =  await _context.Estate.FirstOrDefaultAsync(m => m.Id == id);
            if (estate == null)
            {
                return NotFound();
            }
            Estate = estate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateExists(Estate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstateExists(int id)
        {
          return (_context.Estate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
