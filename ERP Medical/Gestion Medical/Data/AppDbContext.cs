using Gestion_Medical.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medical.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration Patient
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.NumCNAM).IsRequired().HasMaxLength(20);
                entity.Property(p => p.Nom).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Prenom).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Sexe).IsRequired().HasMaxLength(10);
                entity.Property(p => p.Age).IsRequired();
            });

            // Configuration Consultation
            modelBuilder.Entity<Consultation>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.DateConsultation).IsRequired();
                entity.Property(c => c.Diagnostique).IsRequired();
                entity.Property(c => c.Traitement).IsRequired();
                entity.Property(c => c.EstVisite).IsRequired();
                entity.Property(c => c.Prix).HasColumnType("decimal(18,2)");

                entity.HasOne<Patient>()
                      .WithMany(p => p.Consultations)
                      .HasForeignKey(c => c.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
