using DinkToPdf.Contracts;
using DinkToPdf;
using Gestion_Clientele.Data;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Entity.Repository;
using Gestion_Clientele.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddControllersWithViews();

// Configuration de la base de données
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration du repository pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configuration de DinkToPdf
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

// Configuration du pipeline HTTP

// Initialisation de la base de données
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();

        // Applique les migrations automatiquement
        context.Database.Migrate();

        // Initialise les données de test
        await SeedData.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Une erreur est survenue lors de l'initialisation de la base de données.");
    }
}

// Configuration pour l'environnement de production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuration des routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();