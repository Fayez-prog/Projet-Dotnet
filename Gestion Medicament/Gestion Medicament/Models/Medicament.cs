using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Medicament.Models
{
    public class Medicament
    {
        [Key]
        public string Reference { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
        [ValidateNever]
        public ICollection<LigneLivraison> LigneLivraisons { get; set; }
    }
}
