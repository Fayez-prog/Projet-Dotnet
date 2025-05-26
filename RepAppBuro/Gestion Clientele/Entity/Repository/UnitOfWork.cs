using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;

namespace Gestion_Clientele.Entity.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            Appareils = new AppareilRepository(_context);
            DemandesReparation = new DemandeReparationRepository(_context);
            Reparations = new ReparationRepository(_context);
            Factures = new FactureRepository(_context);
            TypePieces = new TypePieceRepository(_context);
            PiecesRecharge = new PieceRechargeRepository(_context);
        }

        public IClientRepository Clients { get; private set; }
        public IAppareilRepository Appareils { get; private set; }
        public IDemandeReparationRepository DemandesReparation { get; private set; }
        public IReparationRepository Reparations { get; private set; }
        public IFactureRepository Factures { get; private set; }
        public ITypePieceRepository TypePieces { get; private set; }
        public IPieceRechargeRepository PiecesRecharge { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
