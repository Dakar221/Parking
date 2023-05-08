using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Voitures
{
    public class DetailsModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public DetailsModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

      public Voiture Voiture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voiture == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voiture.FirstOrDefaultAsync(m => m.VoitureId == id);
            if (voiture == null)
            {
                return NotFound();
            }
            else 
            {
                Voiture = voiture;
            }
            return Page();
        }
    }
}
