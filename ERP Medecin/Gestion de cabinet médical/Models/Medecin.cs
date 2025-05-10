using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Models
{
    public class Medecin
    {
        public int Id { get; set; }
        public string CIN { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; }
        public List<RendezVous> RendezVous { get; set; } = new();
    }
}
