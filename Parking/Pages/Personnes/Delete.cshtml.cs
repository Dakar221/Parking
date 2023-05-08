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
    public class DeleteModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public DeleteModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Personne Personne { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personne == null)
            {
                return NotFound();
            }

            var personne = await _context.Personne.FirstOrDefaultAsync(m => m.PersonneId == id);

            if (personne == null)
            {
                return NotFound();
            }
            else 
            {
                Personne = personne;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personne == null)
            {
                return NotFound();
            }
            var personne = await _context.Personne.FindAsync(id);

            if (personne != null)
            {
                Personne = personne;
                _context.Personne.Remove(Personne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
