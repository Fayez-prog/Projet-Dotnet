using Gestion_de_cabinet_médical.Models;
using Gestion_de_cabinet_médical.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public class RendezVousService : IRendezVousService
    {
        private readonly IRendezVousRepository rendezvous_repository;

        // Injection du repository via le constructeur
        public RendezVousService(IRendezVousRepository RendezVousRepository)
        {
            rendezvous_repository = RendezVousRepository;
        }

        public void AjouterRendezVous(RendezVous rendezvous) => rendezvous_repository.Ajouter(rendezvous);
        public void ModifierRendezVous(RendezVous rendezvous) => rendezvous_repository.Modifier(rendezvous);
        public void SupprimerRendezVous(int id) => rendezvous_repository.Supprimer(id);
        public RendezVous GetRendezVousById(int id) => rendezvous_repository.GetByIdRdv(id);
        public IEnumerable<RendezVous> GetAllRendezVous() => rendezvous_repository.GetAllRdv();
        public bool VerifierDisponibilite(DateTime dateHeure, int medecinId) => rendezvous_repository.VerifierDisponibilite(dateHeure, medecinId);
        public IEnumerable<RendezVous> GetRendezVousByMedecin(int medecinId) => rendezvous_repository.GetRdvByMedecin(medecinId);
        public IEnumerable<RendezVous> GetRendezVousByPatient(int patientId) => rendezvous_repository.GetRdvByPatient(patientId);
        public IEnumerable<RendezVous> GetRendezVousByDate(DateTime date) => rendezvous_repository.GetRdvByDate(date);
    }
}
