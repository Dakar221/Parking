using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Voiture
    {
        public int VoitureId { get; set; }
        public string Matricule { get; set; }
        public string Modele { get; set; }
        public String Marque { get; set; }
        [DataType(DataType.Date)]
        public DateTime Annee { get; set; }
    }
}
