using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class ReparationRepository : Repository<Reparation>, IReparationRepository
    {
        public ReparationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Reparation> GetReparationWithDemandeAndFactureAsync(int id)
        {
            return await _context.Reparations
                .Include(r => r.DemandeReparation)
                .Include(r => r.Facture)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reparation>> GetReparationsByDemandeIdAsync(int demandeId)
        {
            return await _context.Reparations
                .Where(r => r.DemandeReparationId == demandeId)
                .ToListAsync();
        }
    }
}
