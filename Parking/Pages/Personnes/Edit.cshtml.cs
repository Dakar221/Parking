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

namespace Parking.Pages.Personnes
{
    public class EditModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public EditModel(Parking.Data.ParkingContext context)
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

            var personne =  await _context.Personne.FirstOrDefaultAsync(m => m.PersonneId == id);
            if (personne == null)
            {
                return NotFound();
            }
            Personne = personne;
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

            _context.Attach(Personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(Personne.PersonneId))
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

        private bool PersonneExists(int id)
        {
          return (_context.Personne?.Any(e => e.PersonneId == id)).GetValueOrDefault();
        }
    }
}
