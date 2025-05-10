using Gestion_de_cabinet_médical.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public class RendezVousRepository : IRendezVousRepository
    {
        private readonly CabinetContext _context;

        public RendezVousRepository(CabinetContext context)
        {
            _context = context;
        }

        public void Ajouter(RendezVous rendezvous)
        {
            _context.RendezVous.Add(rendezvous);
            _context.SaveChanges();
        }

        public IEnumerable<RendezVous> GetAllRdv()
        {
            return _context.RendezVous
                  .Include(r => r.Medecin)
                  .Include(r => r.Patient)
                  .Where(r => r.Medecin != null && r.Patient != null)
                  .ToList();
        }

        public RendezVous GetByIdRdv(int id)
        {
            return _context.RendezVous.Find(id);
        }

        public void Modifier(RendezVous rendezvous)
        {
            _context.RendezVous.Update(rendezvous);
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var rendezvous = _context.RendezVous.Find(id);
            if (rendezvous != null)
            {
                _context.RendezVous.Remove(rendezvous);
                _context.SaveChanges();
            }
        }

        public bool VerifierDisponibilite(DateTime dateHeure, int medecinId)
        {
            return !_context.RendezVous.Any(r => r.MedecinId == medecinId && r.DateHeure == dateHeure);
        }

        public IEnumerable<RendezVous> GetRdvByMedecin(int medecinId)
        {
            return _context.RendezVous.Where(r => r.MedecinId == medecinId).ToList();
        }

        public IEnumerable<RendezVous> GetRdvByPatient(int patientId)
        {
            return _context.RendezVous.Where(r => r.PatientId == patientId).ToList();
        }

        public IEnumerable<RendezVous> GetRdvByDate(DateTime date)
        {
            return _context.RendezVous.Where(r => r.DateHeure.Date == date.Date).ToList();
        }
    }
}
