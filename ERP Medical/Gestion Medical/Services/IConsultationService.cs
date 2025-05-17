using Gestion_Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Services
{
    public interface IConsultationService
    {
        IEnumerable<Consultation> GetConsultationsByPatientId(int patientId);
        IEnumerable<Consultation> GetAllConsultations();
        Consultation GetConsultationById(int id);
        void AddConsultation(Consultation consultation);
        void UpdateConsultation(Consultation consultation);
        void DeleteConsultation(int id);
    }
}
