using Gestion_de_cabinet_médical.Models;
using Gestion_de_cabinet_médical.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public class MedecinService : IMedecinService
    {
        private readonly IMedecinRepository medecin_repository;

        public MedecinService(IMedecinRepository MedecinRepository)
        {
            medecin_repository = MedecinRepository;
        }

        public void AjouterMedecin(Medecin medecin) => medecin_repository.Ajouter(medecin);
        public IEnumerable<Medecin> GetAllMedecins() => medecin_repository.GetAllMed();
        public Medecin GetMedecinById(int id) => medecin_repository.GetByIdMed(id);
        public void ModifierMedecin(Medecin medecin) => medecin_repository.Modifier(medecin);
        public void SupprimerMedecin(int id) => medecin_repository.Supprimer(id);
        public IEnumerable<Medecin> RechercherParAdresse(string adresse) => medecin_repository.RechercherParAdresse(adresse);
    }
}
