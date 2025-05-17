using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public interface IMedecinService
    {
        void AjouterMedecin(Medecin medecin);
        IEnumerable<Medecin> GetAllMedecins();
        Medecin GetMedecinById(int id);
        void ModifierMedecin(Medecin medecin);
        IEnumerable<Medecin> RechercherParAdresse(string adresse);
        void SupprimerMedecin(int id);
    }
}
