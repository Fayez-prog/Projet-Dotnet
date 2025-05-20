using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string CIN { get; set; }
        public string NumCNAM { get; set; }
        public string TypeCNAM { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public int Age { get; set; }
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();

        public Consultation ChercherDerniereConsul()
        {
            if (Consultations.Count == 0) return null;

            Consultation derniere = Consultations[0];
            foreach (var consul in Consultations)
            {
                if (consul.DateConsultation > derniere.DateConsultation)
                    derniere = consul;
            }
            return derniere;
        }
    }
}
