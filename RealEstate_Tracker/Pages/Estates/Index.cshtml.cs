using System;
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
    
    public class IndexModel : PageModel
    {
        private readonly RealEstate_Tracker.Data.RealEstate_TrackerContext _context;

        public IndexModel(RealEstate_Tracker.Data.RealEstate_TrackerContext context)
        {
            _context = context;
        }

        public IList<Estate> Estate { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Estate_Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Type_of_Property_Genre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> estate_genre_Query = from m in _context.Estate
                                                    orderby m.Type_of_Estate
                                                    select m.Type_of_Estate;

            var estates = from m in _context.Estate
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                estates = estates.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Type_of_Property_Genre))
            {
                estates = estates.Where(x => x.Type_of_Estate == Type_of_Property_Genre);
            
            }
            Estate_Genres = new SelectList(await estate_genre_Query.Distinct().ToListAsync());
            Estate = await estates.ToListAsync();
        }
    }
}
