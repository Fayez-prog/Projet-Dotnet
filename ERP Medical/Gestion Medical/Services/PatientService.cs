using Gestion_Medical.Models;
using Gestion_Medical.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient GetPatientByNumCNAM(string numCNAM)
        {
            return _patientRepository.GetByNumCNAM(numCNAM);
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        public void DeletePatient(int id)
        {
            _patientRepository.Delete(id);
        }
    }
}
