using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_cabinet_médical.Models
{
    public class CabinetContext : DbContext
    {
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=DBrdv;Integrated Security=True;");
        }
    }
}
