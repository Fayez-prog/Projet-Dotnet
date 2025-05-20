using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Clientele.Models
{
    public class PieceRecharge
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public decimal PrixHT { get; set; }
        public decimal PrixTTC { get; set; }
        public decimal PrixAChat { get; set; }

        public int TypePieceId { get; set; }
        [ValidateNever]
        public TypePiece TypePiece { get; set; }
    }
}
