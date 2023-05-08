using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.Locations
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

            var requete = from e in _context.Set<Personne>()
                          select new
                          {
                              nomComplet = e.Nom + " " + e.Prenom,
                              value = e.PersonneId

                          };


            var listePersonne = requete.Select(i => new SelectListItem()
            {
                Text = i.nomComplet,
                Value = i.value.ToString()
            });
            var requetevoiture = from v in _context.Set<Voiture>()
                          select new
                          {
                              nomVoiture = v.Marque ,
                              value = v.VoitureId
                          };


            var listeVoiture = requetevoiture.Select(i => new SelectListItem()
            {
                Text = i.nomVoiture,
                Value = i.value.ToString()
            });

            ViewData["VoitureId"] = new SelectList(listeVoiture, "Value", "Text");
            ViewData["PersonneId"] = new SelectList(listePersonne, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Location Location { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([Bind("LocationId,VoitureId,PersonneId,Tarif,DateRetour,DateRetourPrevue,DateLocation ")] Location location)
        {
            /*if (!ModelState.IsValid || _context.Location == null || Location == null)
              {
                  return Page();
              }

              _context.Location.Add(Location);
              await _context.SaveChangesAsync();
            */
            _context.Add(location);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToPage("./Index");
        }
    }
}
