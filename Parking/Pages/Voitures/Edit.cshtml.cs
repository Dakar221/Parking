using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Voitures
{
    public class EditModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public EditModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voiture Voiture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voiture == null)
            {
                return NotFound();
            }

            var voiture =  await _context.Voiture.FirstOrDefaultAsync(m => m.VoitureId == id);
            if (voiture == null)
            {
                return NotFound();
            }
            Voiture = voiture;
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

            _context.Attach(Voiture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoitureExists(Voiture.VoitureId))
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

        private bool VoitureExists(int id)
        {
          return (_context.Voiture?.Any(e => e.VoitureId == id)).GetValueOrDefault();
        }
    }
}
