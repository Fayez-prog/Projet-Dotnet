using Gestion_Etudiants.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Etudiants.Data
{
    public class StudentContext : IdentityDbContext<IdentityUser>
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SchoolID)
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression de l'école

            base.OnModelCreating(modelBuilder); // Nécessaire pour la configuration d'Identity

            // Configuration supplémentaire pour vos entités
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<School>().ToTable("Schools");
        }
    }
}
