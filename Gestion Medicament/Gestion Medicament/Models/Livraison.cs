using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Medicament.Models
{
    public class Livraison
    {
        [Key]
        public string Numero { get; set; }
        public string Fournisseur { get; set; }
        public DateTime DateLiv { get; set; }
        public double Total { get; set; }
        [ValidateNever]
        public ICollection<LigneLivraison> Lignes { get; set; }
    }
}
