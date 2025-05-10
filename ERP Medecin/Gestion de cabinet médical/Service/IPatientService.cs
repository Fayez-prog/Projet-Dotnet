using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public interface IPatientService
    {
        void AjouterPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        void ModifierPatient(Patient patient);
        IEnumerable<Patient> RechercherParNom(string nom);
        void SupprimerPatient(int id);
    }
}
