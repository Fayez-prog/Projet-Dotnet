using Gestion_Medical.Models;
using Gestion_Medical.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public IEnumerable<Consultation> GetAllConsultations()
        {
            return _consultationRepository.GetAll();
        }

        public IEnumerable<Consultation> GetConsultationsByPatientId(int patientId)
        {
            return _consultationRepository.GetByPatientId(patientId);
        }

        public Consultation GetConsultationById(int id)
        {
            return _consultationRepository.GetById(id);
        }

        public void AddConsultation(Consultation consultation)
        {
            _consultationRepository.Add(consultation);
        }

        public void UpdateConsultation(Consultation consultation)
        {
            _consultationRepository.Update(consultation);
        }

        public void DeleteConsultation(int id)
        {
            _consultationRepository.Delete(id);
        }
    }
}
