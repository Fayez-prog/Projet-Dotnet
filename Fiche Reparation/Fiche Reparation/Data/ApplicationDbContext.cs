using Fiche_Reparation.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiche_Reparation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<DemandeReparation> DemandeReparations { get; set; }

    }
}
