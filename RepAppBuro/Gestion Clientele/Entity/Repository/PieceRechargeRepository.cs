using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Entity.Repository
{
    public class PieceRechargeRepository : Repository<PieceRecharge>, IPieceRechargeRepository
    {
        public PieceRechargeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PieceRecharge> GetPieceWithTypePieceAsync(int id)
        {
            return await _context.PiecesRecharge
                .Include(p => p.TypePiece)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PieceRecharge>> GetPiecesByTypePieceIdAsync(int typePieceId)
        {
            return await _context.PiecesRecharge
                .Where(p => p.TypePieceId == typePieceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PieceRecharge>> GetPiecesLowStockAsync(int seuil)
        {
            return await _context.PiecesRecharge
                .Where(p => p.Quantite <= seuil)
                .ToListAsync();
        }

        public async Task<IEnumerable<PieceRecharge>> GetPiecesWithTypePieceAsync()
        {
            return await _context.PiecesRecharge
                .Include(p => p.TypePiece)
                .ToListAsync();
        }
    }
}
