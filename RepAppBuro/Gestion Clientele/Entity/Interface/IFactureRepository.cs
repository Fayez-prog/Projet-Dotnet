using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IFactureRepository : IRepository<Facture>
    {
        Task<Facture> GetFactureWithReparationAsync(int id);
        Task<Facture> GetFactureByNumeroAsync(string numero);
        Task<string> GenerateNextInvoiceNumberAsync();
        Task<IEnumerable<Facture>> GetFactureWithReparationAsync();
    }
}
