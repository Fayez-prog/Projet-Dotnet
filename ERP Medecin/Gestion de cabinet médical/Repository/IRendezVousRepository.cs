using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public interface IRendezVousRepository
    {
        void Ajouter(RendezVous rendezvous);
        RendezVous GetByIdRdv(int id);
        IEnumerable<RendezVous> GetAllRdv();
        void Modifier(RendezVous rendezvous);
        void Supprimer(int id);
        bool VerifierDisponibilite(DateTime dateHeure, int medecinId);
        IEnumerable<RendezVous> GetRdvByMedecin(int medecinId);
        IEnumerable<RendezVous> GetRdvByPatient(int patientId);
        IEnumerable<RendezVous> GetRdvByDate(DateTime date);
    }
}
