using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;

namespace Gestion_Medicament.Entity.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmacieDbContext _context;
        private IMedicamentRepository _medicaments;
        private ILivraisonRepository _livraisons;
        private ILigneLivraisonRepository _ligneLivraisons;

        public UnitOfWork(PharmacieDbContext context)
        {
            _context = context;
        }

        public IMedicamentRepository Medicaments
        {
            get
            {
                if (_medicaments == null)
                {
                    _medicaments = new MedicamentRepository(_context);
                }
                return _medicaments;
            }
        }

        public ILivraisonRepository Livraisons
        {
            get
            {
                if (_livraisons == null)
                {
                    _livraisons = new LivraisonRepository(_context);
                }
                return _livraisons;
            }
        }

        public ILigneLivraisonRepository LigneLivraisons
        {
            get
            {
                if (_ligneLivraisons == null)
                {
                    _ligneLivraisons = new LigneLivraisonRepository(_context);
                }
                return _ligneLivraisons;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
