using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Interface
{
    public interface IUnitOfWork
    {
        IClientRepository Clients { get; }
        IAppareilRepository Appareils { get; }
        IDemandeReparationRepository DemandesReparation { get; }
        IReparationRepository Reparations { get; }
        IFactureRepository Factures { get; }
        ITypePieceRepository TypePieces { get; }
        IPieceRechargeRepository PiecesRecharge { get; }
        Task<int> CompleteAsync();
    }
}
