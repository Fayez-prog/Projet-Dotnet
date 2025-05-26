using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IPieceRechargeRepository : IRepository<PieceRecharge>
    {
        Task<PieceRecharge> GetPieceWithTypePieceAsync(int id);
        Task<IEnumerable<PieceRecharge>> GetPiecesByTypePieceIdAsync(int typePieceId);
        Task<IEnumerable<PieceRecharge>> GetPiecesLowStockAsync(int seuil);
        Task<IEnumerable<PieceRecharge>> GetPiecesWithTypePieceAsync();
    }
}
