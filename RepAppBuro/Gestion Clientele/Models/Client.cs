using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string NumTel { get; set; }
        [ValidateNever]
        public ICollection<Appareil> Appareils { get; set; }
        [ValidateNever]
        public ICollection<DemandeReparation> DemandesReparation { get; set; }
    }
}
