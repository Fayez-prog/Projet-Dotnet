using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public interface IRendezVousService
    {
        void AjouterRendezVous(RendezVous rendezvous);
        IEnumerable<RendezVous> GetAllRendezVous();
        RendezVous GetRendezVousById(int id);
        void ModifierRendezVous(RendezVous rendezvous);
        void SupprimerRendezVous(int id);
        bool VerifierDisponibilite(DateTime dateHeure, int medecinId);
        IEnumerable<RendezVous> GetRendezVousByMedecin(int medecinId);
        IEnumerable<RendezVous> GetRendezVousByPatient(int patientId);
        IEnumerable<RendezVous> GetRendezVousByDate(DateTime date);
    }
}
