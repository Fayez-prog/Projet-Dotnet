using Gestion_Medical.Data;
using Gestion_Medical.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Repository
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly AppDbContext _context;

        public ConsultationRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Consultation> GetAll()
        {
            return _context.Consultations
                .OrderByDescending(c => c.DateConsultation)
                .ToList();
        }

        public IEnumerable<Consultation> GetByPatientId(int patientId)
        {
            return _context.Consultations
                .Where(c => c.PatientId == patientId)
                .OrderByDescending(c => c.DateConsultation)
                .ToList();
        }

        public Consultation GetById(int id)
        {
            return _context.Consultations.Find(id);
        }

        public void Add(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void Update(Consultation consultation)
        {
            _context.Entry(consultation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var consultation = _context.Consultations.Find(id);
            if (consultation != null)
            {
                _context.Consultations.Remove(consultation);
                _context.SaveChanges();
            }
        }
    }
}
