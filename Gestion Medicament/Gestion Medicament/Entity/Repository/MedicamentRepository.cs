using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Medicament.Entity.Repository
{
    public class MedicamentRepository : Repository<Medicament>, IMedicamentRepository
    {
        public MedicamentRepository(PharmacieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Medicament>> GetMedicamentsLowStockAsync(int seuil)
        {
            return await Context.Medicaments
                .Where(m => m.Quantite < seuil)
                .OrderBy(m => m.Quantite)
                .ToListAsync();
        }

        public async Task UpdateStockAsync(string reference, int quantiteAjoutee)
        {
            var medicament = await Context.Medicaments.FindAsync(reference);
            if (medicament != null)
            {
                medicament.Quantite += quantiteAjoutee;
                Context.Entry(medicament).State = EntityState.Modified;
            }
        }

        public async Task<double> GetTotalStockValueAsync()
        {
            return await Context.Medicaments
                .SumAsync(m => m.Quantite * m.Prix);
        }

        public async Task<IEnumerable<Medicament>> GetAvailableMedicamentsAsync()
        {
            return await Context.Medicaments
                .Where(m => m.Quantite > 0)
                .OrderBy(m => m.Description)
                .ToListAsync();
        }
    }
}
