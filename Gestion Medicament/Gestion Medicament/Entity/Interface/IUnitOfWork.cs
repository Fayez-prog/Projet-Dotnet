using Gestion_Medicament.Models;

namespace Gestion_Medicament.Entity.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IMedicamentRepository Medicaments { get; }
        ILivraisonRepository Livraisons { get; }
        ILigneLivraisonRepository LigneLivraisons { get; }
        Task<int> CompleteAsync();
    }
}
