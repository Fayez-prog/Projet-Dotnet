using Gestion_de_cabinet_médical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Repository
{
    public class MedecinRepository : IMedecinRepository
    {
        private readonly CabinetContext _context;

        public MedecinRepository(CabinetContext context)
        {
            _context = context;
        }

        public void Ajouter(Medecin medecin)
        {
            _context.Medecins.Add(medecin);
            _context.SaveChanges();
        }

        public IEnumerable<Medecin> GetAllMed()
        {
            return _context.Medecins.ToList();
        }

        public Medecin GetByIdMed(int id)
        {
            return _context.Medecins.Find(id);
        }

        public void Modifier(Medecin medecin)
        {
            var existingMedecin = _context.Medecins.Find(medecin.Id);
            if (existingMedecin == null)
            {
                throw new InvalidOperationException("Le médecin n'existe pas.");
            }

            _context.Entry(existingMedecin).CurrentValues.SetValues(medecin);
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var medecin = _context.Medecins.Find(id);
            if (medecin != null)
            {
                _context.Medecins.Remove(medecin);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Medecin> RechercherParAdresse(string adresse)
        {
            return _context.Medecins
            .Where(m => m.Adresse.ToLower().Contains(adresse.ToLower()))
            .ToList();
        }
    }
}
