using Gestion_Medical.Data;
using Gestion_Medical.Models;
using Gestion_Medical.Repository;
using Gestion_Medical.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gestion_Medical
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();

            // Assurez-vous que la base de données est créée
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<MenuCabinetNomMatricule>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Configuration de la base de données
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GestionMedicalDB;Trusted_Connection=True;MultipleActiveResultSets=true"));

            // Enregistrement des repositories
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();

            // Enregistrement des services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultationService, ConsultationService>();

            // Enregistrement des formulaires
            services.AddTransient<MenuCabinetNomMatricule>();
            services.AddTransient<GestionPatients>();
            services.AddTransient<GestionConsultations>();
        }
    }
}