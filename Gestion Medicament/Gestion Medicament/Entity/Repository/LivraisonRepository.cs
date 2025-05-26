using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Medicament.Entity.Repository
{
    public class LivraisonRepository : Repository<Livraison>, ILivraisonRepository
    {
        public LivraisonRepository(PharmacieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Livraison>> GetLivraisonsByDateAsync(DateTime dateDebut, DateTime dateFin)
        {
            return await Context.Livraisons
                .Where(l => l.DateLiv >= dateDebut && l.DateLiv <= dateFin)
                .OrderByDescending(l => l.DateLiv)
                .ToListAsync();
        }

        public async Task<IEnumerable<Livraison>> GetLivraisonsByFournisseurAsync(string fournisseur)
        {
            return await Context.Livraisons
                .Where(l => l.Fournisseur.Contains(fournisseur))
                .OrderByDescending(l => l.DateLiv)
                .ToListAsync();
        }

        public async Task<double> GetTotalLivraisonsAsync(DateTime? dateDebut = null, DateTime? dateFin = null)
        {
            var query = Context.Livraisons.AsQueryable();

            if (dateDebut.HasValue)
                query = query.Where(l => l.DateLiv >= dateDebut.Value);

            if (dateFin.HasValue)
                query = query.Where(l => l.DateLiv <= dateFin.Value);

            return await query.SumAsync(l => l.Total);
        }

        public async Task<bool> ExistsAsync(string numLiv)
        {
            return await Context.Livraisons
                .AnyAsync(l => l.Numero == numLiv);
        }
    }
}
