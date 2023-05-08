using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public IndexModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Location != null)
            {
                Location = await _context.Location
                .Include(l => l.Laviture)
                .Include(l => l.Locataire).ToListAsync();
            }
        }
    }
}
