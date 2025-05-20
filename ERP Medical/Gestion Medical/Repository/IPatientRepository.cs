using Gestion_Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        Patient GetByNumCNAM(string numCNAM);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int id);
    }
}
