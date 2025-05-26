using Gestion_Medicament.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Medicament.Data
{
    public class PharmacieDbContext : DbContext
    {
        public PharmacieDbContext(DbContextOptions<PharmacieDbContext> options) : base(options)
        {
        }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<LigneLivraison> LigneLivraisons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LigneLivraison>()
                .HasOne(ll => ll.Medicament)
                .WithMany(m => m.LigneLivraisons)
                .HasForeignKey(ll => ll.RefMed)
                .IsRequired();

            modelBuilder.Entity<LigneLivraison>()
                .HasOne(ll => ll.Livraison)
                .WithMany(l => l.Lignes)
                .HasForeignKey(ll => ll.NumLiv)
                .IsRequired();

            // Configuration des propriétés pour Medicament
            modelBuilder.Entity<Medicament>()
                .Property(m => m.Reference)
                .HasMaxLength(50)
                .IsRequired();

            // Configuration des propriétés pour Livraison
            modelBuilder.Entity<Livraison>()
                .Property(l => l.Numero)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
