using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Telephone { get; set; }
        public List<RendezVous> RendezVous { get; set; } = new();
    }
}
