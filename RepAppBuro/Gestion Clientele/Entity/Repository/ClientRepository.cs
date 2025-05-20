using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientWithAppareilsAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Appareils)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> GetClientWithDemandesReparationAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.DemandesReparation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> SearchClientsByNameAsync(string name)
        {
            return await _context.Clients
                .Where(c => c.Nom.Contains(name))
                .ToListAsync();
        }
    }
}
