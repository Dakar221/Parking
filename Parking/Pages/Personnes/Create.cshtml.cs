using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Personnes
{
    public class CreateModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public CreateModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personne Personne { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Personne == null || Personne == null)
            {
                return Page();
            }

            _context.Personne.Add(Personne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
