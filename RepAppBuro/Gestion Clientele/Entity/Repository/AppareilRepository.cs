using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class AppareilRepository : Repository<Appareil>, IAppareilRepository
    {
        public AppareilRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Appareil> GetAppareilWithClientAsync(int id)
        {
            return await _context.Appareils
                .Include(a => a.Client)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appareil>> GetAppareilsByClientIdAsync(int clientId)
        {
            return await _context.Appareils
                .Where(a => a.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appareil>> GetAllAppareilsWithClientsAsync()
        {
            return await _context.Appareils
                .Include(a => a.Client)
                .ToListAsync();
        }
    }
}
