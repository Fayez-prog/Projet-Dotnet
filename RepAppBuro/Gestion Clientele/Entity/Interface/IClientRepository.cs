using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientWithAppareilsAsync(int id);
        Task<Client> GetClientWithDemandesReparationAsync(int id);
        Task<IEnumerable<Client>> SearchClientsByNameAsync(string name);
    }
}
