using Gestion_Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Repository
{
    public interface IConsultationRepository
    {
        IEnumerable<Consultation> GetAll();
        IEnumerable<Consultation> GetByPatientId(int patientId);
        Consultation GetById(int id);
        void Add(Consultation consultation);
        void Update(Consultation consultation);
        void Delete(int id);
    }
}
