using Gestion_Medicament.Models;

namespace Gestion_Medicament.Entity.Interface
{
    public interface ILigneLivraisonRepository : IRepository<LigneLivraison>
    {
        Task<IEnumerable<LigneLivraison>> GetLignesByLivraisonAsync(string numLiv);
        Task<IEnumerable<LigneLivraison>> GetLignesByMedicamentAsync(string refMed);
        Task<int> GetTotalQuantiteLivreeAsync(string refMed);
        Task IncludeMedicamentAndLivraison(LigneLivraison ligneLivraison);
    }
}
