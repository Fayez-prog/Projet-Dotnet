using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class TypePiece
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Tarif { get; set; }
        [ValidateNever]
        public ICollection<PieceRecharge> PiecesRecharge { get; set; }
    }
}
