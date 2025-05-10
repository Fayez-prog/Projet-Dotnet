using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Models
{
    public class RendezVous
    {
        public int Id { get; set; }
        public DateTime DateHeure { get; set; }
        public int MedecinId { get; set; }
        public Medecin Medecin { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } 
    }
}
