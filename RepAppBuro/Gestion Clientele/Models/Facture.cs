using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal MontantTotal { get; set; }
        public string Numero { get; set; }

        // Liaison avec Reparation
        public int ReparationId { get; set; }
        [ValidateNever]
        public Reparation Reparation { get; set; }
    }
}
