using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IDemandeReparationRepository : IRepository<DemandeReparation>
    {
        Task<DemandeReparation> GetDemandeWithClientAndAppareilAsync(int id);
        Task<DemandeReparation> GetDemandeWithReparationsAsync(int id);
        Task<IEnumerable<DemandeReparation>> GetDemandesByClientIdAsync(int clientId);
        Task<IEnumerable<DemandeReparation>> GetDemandesByEtatAsync(string etat);
        Task<IEnumerable<DemandeReparation>> GetAllWithClientAndAppareilAsync();
    }
}
