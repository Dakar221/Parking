using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext (DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public DbSet<Parking.Models.Location> Location { get; set; } = default!;

        public DbSet<Parking.Models.Personne> Personne { get; set; } = default!;

        public DbSet<Parking.Models.Voiture> Voiture { get; set; } = default!;
    }
}
