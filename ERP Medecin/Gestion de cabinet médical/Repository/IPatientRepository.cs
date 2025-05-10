using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public interface IPatientRepository
    {
        void Ajouter(Patient patient);
        Patient GetByIdPat(int id);
        IEnumerable<Patient> GetAllPat();
        void Modifier(Patient patient);
        void Supprimer(int id);
        IEnumerable<Patient> RechercherParNom(string nom);
    }
}
