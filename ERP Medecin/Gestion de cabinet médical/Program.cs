using Gestion_de_cabinet_médical.Models;
using Gestion_de_cabinet_médical.Repository;
using Gestion_de_cabinet_médical.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Gestion_de_cabinet_médical
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création du conteneur de services
            var services = new ServiceCollection();

            // Enregistrement des services
            ConfigureServices(services);

            // Construction du fournisseur de services
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Récupération du formulaire principal avec ses dépendances
                var form = serviceProvider.GetRequiredService<MDIParent1>();
                Application.Run(form);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Enregistre le DbContext (identique au document)
            services.AddScoped<CabinetContext>();

            // Enregistre les repositories (même pattern que MedecinRepository)
            services.AddScoped<IMedecinRepository, MedecinRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRendezVousRepository, RendezVousRepository>();

            // Enregistre les services métier (même pattern que MedecinService)
            services.AddScoped<IMedecinService, MedecinService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IRendezVousService, RendezVousService>();

            // Enregistre le formulaire principal (identique au document)
            services.AddScoped<MDIParent1>();
        }
    }
}