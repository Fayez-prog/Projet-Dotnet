using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class DemandeReparation
    {
        public int Id { get; set; }
        public DateTime DateDepotAppareil { get; set; }
        public DateTime DatePrevueRep { get; set; }
        public string Etat { get; set; }
        public string SymptomesPanne { get; set; }

        // Relation avec Appareil
        public int AppareilId { get; set; }
        [ValidateNever]
        public Appareil Appareil { get; set; }

        // Relation avec Client (conservée pour accès direct)
        public int ClientId { get; set; }
        [ValidateNever]
        public Client Client { get; set; }
        [ValidateNever]
        public ICollection<Reparation> Reparations { get; set; }
    }
}
