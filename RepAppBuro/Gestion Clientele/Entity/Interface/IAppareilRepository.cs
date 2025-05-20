using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IAppareilRepository : IRepository<Appareil>
    {
        Task<Appareil> GetAppareilWithClientAsync(int id);
        Task<IEnumerable<Appareil>> GetAppareilsByClientIdAsync(int clientId);
        Task<IEnumerable<Appareil>> GetAllAppareilsWithClientsAsync();
    }
}
