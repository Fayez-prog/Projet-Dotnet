using Gestion_Medicament.Models;

namespace Gestion_Medicament.Entity.Interface
{
    public interface IMedicamentRepository : IRepository<Medicament>
    {
        Task<IEnumerable<Medicament>> GetMedicamentsLowStockAsync(int seuil);
        Task UpdateStockAsync(string reference, int quantiteAjoutee);
        Task<double> GetTotalStockValueAsync();
        Task<IEnumerable<Medicament>> GetAvailableMedicamentsAsync();
    }
}

