namespace Parking.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public DateTime DateLocation { get; set; }
        public DateTime DateRetourPrevue { get; set; }
        public DateTime? DateRetour { get; set; }
        public int Tarif { get; set; }
        public int PersonneId { get; set; }
        public int VoitureId { get; set; }
        public Personne Locataire { get; set; }
       
        public Voiture Laviture { get; set; }



    }
}
