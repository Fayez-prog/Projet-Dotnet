using Gestion_de_cabinet_médical.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CabinetContext _context;

        public PatientRepository(CabinetContext context)
        {
            _context = context;
        }

        public void Ajouter(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetAllPat()
        {
            return _context.Patients.ToList();
        }

        public Patient GetByIdPat(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Modifier(Patient patient)
        {
            // Vérifier si l'entité est déjà suivie
            var existingPatient = _context.Patients.Local.FirstOrDefault(p => p.Id == patient.Id);

            if (existingPatient != null)
            {
                // Détacher l'entité existante
                _context.Entry(existingPatient).State = EntityState.Detached;
            }

            // Marquer l'entité comme modifiée
            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Patient> RechercherParNom(string nom)
        {
            return _context.Patients
                 .Where(p => EF.Functions.Like(p.Nom, $"%{nom}%"))
                 .AsNoTracking()
                 .ToList();
        }
    }
}
