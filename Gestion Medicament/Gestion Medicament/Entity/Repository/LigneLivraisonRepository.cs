using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Medicament.Entity.Repository
{
    public class LigneLivraisonRepository : Repository<LigneLivraison>, ILigneLivraisonRepository
    {
        public LigneLivraisonRepository(PharmacieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LigneLivraison>> GetLignesByLivraisonAsync(string numLiv)
        {
            return await Context.LigneLivraisons
         .AsNoTracking()
         .Include(ll => ll.Medicament)
         .Include(ll => ll.Livraison)
         .Where(ll => ll.NumLiv == numLiv && ll.Medicament != null) // Filtre explicite
         .ToListAsync();
        }

        public async Task<IEnumerable<LigneLivraison>> GetLignesByMedicamentAsync(string refMed)
        {
            return await Context.LigneLivraisons
      .AsNoTracking()
      .Include(ll => ll.Livraison)
      .Include(ll => ll.Medicament)
      .Where(ll => ll.RefMed == refMed && ll.Livraison != null) // Filtre explicite
      .OrderByDescending(ll => ll.Livraison.DateLiv)
      .ToListAsync();
        }

        public async Task<int> GetTotalQuantiteLivreeAsync(string refMed)
        {
            return await Context.LigneLivraisons
                .Where(ll => ll.RefMed == refMed)
                .SumAsync(ll => ll.Quantite);
        }

        public async Task IncludeMedicamentAndLivraison(LigneLivraison ligneLivraison)
        {
            await Context.Entry(ligneLivraison)
                .Reference(ll => ll.Medicament)
                .LoadAsync();

            await Context.Entry(ligneLivraison)
                .Reference(ll => ll.Livraison)
                .LoadAsync();
        }
    }
}
