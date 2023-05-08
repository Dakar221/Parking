using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Personnes
{
    public class IndexModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public IndexModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        public IList<Personne> Personne { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personne != null)
            {
                Personne = await _context.Personne.ToListAsync();
            }
        }
    }
}
