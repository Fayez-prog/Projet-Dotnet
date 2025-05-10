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
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.Include(p => p.Consultations).ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Include(p => p.Consultations).FirstOrDefault(p => p.Id == id);
        }

        public Patient GetByNumCNAM(string numCNAM)
        {
            return _context.Patients.Include(p => p.Consultations).FirstOrDefault(p => p.NumCNAM == numCNAM);
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
