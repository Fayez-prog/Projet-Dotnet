using Gestion_de_cabinet_médical.Models;
using Gestion_de_cabinet_médical.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Service
{
    public class PatientService :IPatientService
    {
        private readonly IPatientRepository patient_repository;

        public PatientService(IPatientRepository PatientRepository)
        {
            patient_repository = PatientRepository;
        }

        public void AjouterPatient(Patient patient) => patient_repository.Ajouter(patient);
        public IEnumerable<Patient> GetAllPatients() => patient_repository.GetAllPat();
        public Patient GetPatientById(int id) => patient_repository.GetByIdPat(id);
        public void ModifierPatient(Patient patient) => patient_repository.Modifier(patient);
        public void SupprimerPatient(int id) => patient_repository.Supprimer(id);
        public IEnumerable<Patient> RechercherParNom(string nom) => patient_repository.RechercherParNom(nom);
    }
}
