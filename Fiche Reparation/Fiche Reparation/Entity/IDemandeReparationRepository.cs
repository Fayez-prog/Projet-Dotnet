using Fiche_Reparation.Models;

namespace Fiche_Reparation.Entity
{
    public interface IDemandeReparationRepository
    {
        Task<IEnumerable<DemandeReparation>> GetAllAsync();
        Task<DemandeReparation> GetByIdAsync(int id);
        Task<IEnumerable<DemandeReparation>> GetByClientIdAsync(int clientId);
        Task AddAsync(DemandeReparation demande);
        Task UpdateAsync(DemandeReparation demande);
        Task DeleteAsync(int id);
    }
}
