using DinkToPdf.Contracts;
using DinkToPdf;
using Fiche_Reparation.Data;
using Fiche_Reparation.Helpers;
using Microsoft.EntityFrameworkCore;
using Fiche_Reparation.Entity;


var builder = WebApplication.CreateBuilder(args);

//Client
builder.Services.AddScoped<IClientRepository, ClientRepository>();

//DemandeReparation
builder.Services.AddScoped<IDemandeReparationRepository, DemandeReparationRepository>();

// pdf
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddSingleton<PdfService>();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
