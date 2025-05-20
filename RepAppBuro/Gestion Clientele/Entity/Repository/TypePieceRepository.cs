using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class TypePieceRepository : Repository<TypePiece>, ITypePieceRepository
    {
        public TypePieceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TypePiece> GetTypePieceWithPiecesRechargeAsync(int id)
        {
            return await _context.TypePieces
                .Include(t => t.PiecesRecharge)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
