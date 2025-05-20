using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface ITypePieceRepository : IRepository<TypePiece>
    {
        Task<TypePiece> GetTypePieceWithPiecesRechargeAsync(int id);
    }
}
