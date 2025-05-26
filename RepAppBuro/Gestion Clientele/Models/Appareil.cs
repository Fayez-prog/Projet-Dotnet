using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class Appareil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string NumeroSerie { get; set; }
        public string Type { get; set; }

        // Relation avec Client
        public int ClientId { get; set; }
        [ValidateNever]
        public Client Client { get; set; }

        // Relation avec DemandeReparation
        [ValidateNever]
        public ICollection<DemandeReparation> DemandesReparation { get; set; }
    }
}
