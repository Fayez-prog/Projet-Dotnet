using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class Reparation
    {
        public int Id { get; set; }
        public DateTime DateRep { get; set; }
        public string Description { get; set; }
        public decimal TarifMO { get; set; }
        public decimal TempsMO { get; set; }

        // Liaison avec DemandeReparation
        public int DemandeReparationId { get; set; }
        [ValidateNever]
        public DemandeReparation DemandeReparation { get; set; }

        // Liaison avec Facture (1-1)
        [ValidateNever]
        public Facture Facture { get; set; }
    }
}
