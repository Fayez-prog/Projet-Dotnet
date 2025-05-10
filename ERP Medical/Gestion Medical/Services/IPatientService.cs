using Gestion_Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        Patient GetPatientByNumCNAM(string numCNAM);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}
