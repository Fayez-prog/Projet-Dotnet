using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Medicament.Models
{
    public class LigneLivraison
    {
        [Key]
        public int Id { get; set; }

        public int Quantite { get; set; }

        public string Description { get; set; }
        [Required]
        // Foreign keys
        [ForeignKey("Medicament")]
        public string RefMed { get; set; }
        [Required]
        [ForeignKey("Livraison")]
        public string NumLiv { get; set; }

        // Navigation properties
        public Medicament? Medicament { get; set; }
        public Livraison? Livraison { get; set; }
    }
}
