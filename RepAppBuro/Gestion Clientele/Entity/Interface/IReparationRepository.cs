using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IReparationRepository : IRepository<Reparation>
    {
        Task<Reparation> GetReparationWithDemandeAndFactureAsync(int id);
        Task<IEnumerable<Reparation>> GetReparationsByDemandeIdAsync(int demandeId);
    }
}
