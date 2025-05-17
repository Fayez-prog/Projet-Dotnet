using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public interface IMedecinRepository
    {
        void Ajouter(Medecin medecin);
        Medecin GetByIdMed(int id);
        IEnumerable<Medecin> GetAllMed();
        void Modifier(Medecin medecin);
        IEnumerable<Medecin> RechercherParAdresse(string adresse);
        void Supprimer(int id);
    }
}
