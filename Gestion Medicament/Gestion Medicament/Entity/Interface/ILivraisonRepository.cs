using Gestion_Medicament.Models;

namespace Gestion_Medicament.Entity.Interface
{ 
    public interface ILivraisonRepository : IRepository<Livraison>
    {
        Task<IEnumerable<Livraison>> GetLivraisonsByDateAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Livraison>> GetLivraisonsByFournisseurAsync(string fournisseur);
        Task<double> GetTotalLivraisonsAsync(DateTime? dateDebut = null, DateTime? dateFin = null);
        Task<bool> ExistsAsync(string numLiv);
    }
}
