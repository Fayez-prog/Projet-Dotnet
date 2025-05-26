using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Gestion_Clientele.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Déclaration des DbSets
        public DbSet<Client> Clients { get; set; }
        public DbSet<Appareil> Appareils { get; set; }
        public DbSet<DemandeReparation> DemandesReparation { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<TypePiece> TypePieces { get; set; }
        public DbSet<PieceRecharge> PiecesRecharge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations

            // Client -> Appareil (1-n)
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appareils)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Client -> DemandeReparation (1-n)
            modelBuilder.Entity<Client>()
                .HasMany(c => c.DemandesReparation)
                .WithOne(d => d.Client)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appareil -> DemandeReparation (1-n)
            modelBuilder.Entity<Appareil>()
                .HasMany(a => a.DemandesReparation)
                .WithOne(d => d.Appareil)
                .HasForeignKey(d => d.AppareilId)
                .OnDelete(DeleteBehavior.Restrict);

            // DemandeReparation -> Reparation (1-n)
            modelBuilder.Entity<DemandeReparation>()
                .HasMany(d => d.Reparations)
                .WithOne(r => r.DemandeReparation)
                .HasForeignKey(r => r.DemandeReparationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Reparation -> Facture (1-1)
            modelBuilder.Entity<Reparation>()
                .HasOne(r => r.Facture)
                .WithOne(f => f.Reparation)
                .HasForeignKey<Facture>(f => f.ReparationId)
                .OnDelete(DeleteBehavior.Cascade);

            // TypePiece -> PieceRecharge (1-n)
            modelBuilder.Entity<TypePiece>()
                .HasMany(t => t.PiecesRecharge)
                .WithOne(p => p.TypePiece)
                .HasForeignKey(p => p.TypePieceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuration des propriétés spécifiques
            modelBuilder.Entity<Facture>()
                .Property(f => f.MontantTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PieceRecharge>()
                .Property(p => p.PrixHT)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PieceRecharge>()
                .Property(p => p.PrixTTC)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PieceRecharge>()
                .Property(p => p.PrixAChat)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reparation>()
                .Property(r => r.TarifMO)
                .HasColumnType("decimal(18,2)");

            // Configuration des index
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.NumTel)
                .IsUnique();

            modelBuilder.Entity<Appareil>()
                .HasIndex(a => a.NumeroSerie)
                .IsUnique();

            modelBuilder.Entity<Facture>()
                .HasIndex(f => f.Numero)
                .IsUnique();
        }
    }
}
