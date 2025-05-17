using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public DateTime DateConsultation { get; set; }
        public string Diagnostique { get; set; }
        public string Traitement { get; set; }
        public bool EstVisite { get; set; }
        public decimal Prix { get; set; }
        public int PatientId { get; set; }

        // Constructeur sans paramètres requis par EF Core
        public Consultation() { }

        // Constructeur paramétré pour votre code
        public Consultation(DateTime date, string diag, string trait, bool estVisite, decimal prix)
        {
            DateConsultation = date;
            Diagnostique = diag;
            Traitement = trait;
            EstVisite = estVisite;
            Prix = prix;
        }
    }
}
