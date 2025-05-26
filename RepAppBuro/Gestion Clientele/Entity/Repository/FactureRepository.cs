using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class FactureRepository : Repository<Facture>, IFactureRepository
    {
        public FactureRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Facture> GetFactureWithReparationAsync(int id)
        {
            return await _context.Factures
                .Include(f => f.Reparation)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Facture> GetFactureByNumeroAsync(string numero)
        {
            return await _context.Factures
                .FirstOrDefaultAsync(f => f.Numero == numero);
        }

        public async Task<string> GenerateNextInvoiceNumberAsync()
        {
            var lastInvoice = await _context.Factures
                .OrderByDescending(f => f.Id)
                .FirstOrDefaultAsync();

            if (lastInvoice == null)
            {
                return $"FAC-{DateTime.Now.Year}-001";
            }

            var lastNumber = lastInvoice.Numero.Split('-').Last();
            if (int.TryParse(lastNumber, out int number))
            {
                return $"FAC-{DateTime.Now.Year}-{(number + 1).ToString("D3")}";
            }

            // Fallback if parsing fails
            return $"FAC-{DateTime.Now.Year}-{DateTime.Now.Ticks.ToString().Substring(8, 3)}";
        }

        public async Task<IEnumerable<Facture>> GetFactureWithReparationAsync()
        {
            return await _context.Factures
                .Include(f => f.Reparation) // Ensure this line exists
                .ToListAsync();
        }
    }
}
