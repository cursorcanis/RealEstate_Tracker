using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate_Tracker.Models;

namespace RealEstate_Tracker.Data
{
    public class RealEstate_TrackerContext : DbContext
    {
        public RealEstate_TrackerContext (DbContextOptions<RealEstate_TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstate_Tracker.Models.Estate> Estate { get; set; } = default!;
    }
}
