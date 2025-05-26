using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class DemandeReparationRepository : Repository<DemandeReparation>, IDemandeReparationRepository
    {
        public DemandeReparationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<DemandeReparation> GetDemandeWithClientAndAppareilAsync(int id)
        {
            return await _context.DemandesReparation
                .Include(d => d.Client)
                .Include(d => d.Appareil)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DemandeReparation> GetDemandeWithReparationsAsync(int id)
        {
            return await _context.DemandesReparation
                .Include(d => d.Reparations)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DemandeReparation>> GetDemandesByClientIdAsync(int clientId)
        {
            return await _context.DemandesReparation
                .Where(d => d.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DemandeReparation>> GetDemandesByEtatAsync(string etat)
        {
            return await _context.DemandesReparation
                .Where(d => d.Etat == etat)
                .ToListAsync();
        }

        public async Task<IEnumerable<DemandeReparation>> GetAllWithClientAndAppareilAsync()
        {
            return await _context.DemandesReparation
                .Include(d => d.Client)
                .Include(d => d.Appareil)
                .ToListAsync();
        }
    }
}
