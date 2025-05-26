using Gestion_Clientele.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clientele.Models
{
    public static class SeedData
    {
        public static async Task Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Vérifie si la base contient déjà des données
            if (await context.Clients.AnyAsync())
            {
                return; // La base contient déjà des données
            }

            // Ajout des TypePieces
            var typePieces = new TypePiece[]
            {
                new TypePiece { Type = "Processeur", Tarif = 120.50m },
                new TypePiece { Type = "Carte mère", Tarif = 89.99m },
                new TypePiece { Type = "RAM", Tarif = 45.75m },
                new TypePiece { Type = "Disque dur", Tarif = 65.00m },
                new TypePiece { Type = "Carte graphique", Tarif = 250.00m }
            };
            await context.TypePieces.AddRangeAsync(typePieces);
            await context.SaveChangesAsync();

            // Ajout des PiecesRecharge
            var pieces = new PieceRecharge[]
            {
                new PieceRecharge { Code = "CPU-001", Nom = "Intel i7", Quantite = 15, PrixHT = 300.00m, PrixTTC = 360.00m, PrixAChat = 380.00m, TypePieceId = typePieces[0].Id },
                new PieceRecharge { Code = "MB-001", Nom = "Asus ROG", Quantite = 8, PrixHT = 150.00m, PrixTTC = 180.00m, PrixAChat = 200.00m, TypePieceId = typePieces[1].Id },
                new PieceRecharge { Code = "RAM-001", Nom = "Corsair 16GB", Quantite = 20, PrixHT = 70.00m, PrixTTC = 84.00m, PrixAChat = 90.00m, TypePieceId = typePieces[2].Id },
                new PieceRecharge { Code = "HDD-001", Nom = "Seagate 1TB", Quantite = 5, PrixHT = 50.00m, PrixTTC = 60.00m, PrixAChat = 65.00m, TypePieceId = typePieces[3].Id }
            };
            await context.PiecesRecharge.AddRangeAsync(pieces);
            await context.SaveChangesAsync();

            // Ajout des Clients
            var clients = new Client[]
            {
                new Client { Nom = "Dupont", Adresse = "12 rue des Lilas, Paris", NumTel = "0123456789" },
                new Client { Nom = "Martin", Adresse = "25 avenue des Roses, Lyon", NumTel = "0234567891"},
                new Client { Nom = "Bernard", Adresse = "8 boulevard des Chênes, Marseille", NumTel = "0345678912"}
            };
            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();

            // Ajout des Appareils
            var appareils = new Appareil[]
            {
                new Appareil { Name = "PC Bureau", Marque = "Dell", Modele = "XPS 15", NumeroSerie = "SN001", Type = "Ordinateur portable", ClientId = clients[0].Id },
                new Appareil { Name = "PC Portable", Marque = "HP", Modele = "Pavilion", NumeroSerie = "SN002", Type = "Ordinateur portable", ClientId = clients[1].Id },
                new Appareil { Name = "Serveur", Marque = "Lenovo", Modele = "ThinkServer", NumeroSerie = "SN003", Type = "Serveur", ClientId = clients[2].Id }
            };
            await context.Appareils.AddRangeAsync(appareils);
            await context.SaveChangesAsync();

            // Ajout des DemandesReparation
            var demandes = new DemandeReparation[]
            {
                new DemandeReparation {
                    DateDepotAppareil = DateTime.Now.AddDays(-7),
                    DatePrevueRep = DateTime.Now.AddDays(3),
                    Etat = "En cours",
                    SymptomesPanne = "Ne démarre pas",
                    AppareilId = appareils[0].Id,
                    ClientId = clients[0].Id
                },
                new DemandeReparation {
                    DateDepotAppareil = DateTime.Now.AddDays(-3),
                    DatePrevueRep = DateTime.Now.AddDays(5),
                    Etat = "En attente",
                    SymptomesPanne = "Ecran cassé",
                    AppareilId = appareils[1].Id,
                    ClientId = clients[1].Id
                }
            };
            await context.DemandesReparation.AddRangeAsync(demandes);
            await context.SaveChangesAsync();

            // Ajout des Reparations
            var reparations = new Reparation[]
            {
                new Reparation {
                    DateRep = DateTime.Now.AddDays(-2),
                    Description = "Remplacement carte mère",
                    TarifMO = 50.00m,
                    TempsMO = 2.5m,
                    DemandeReparationId = demandes[0].Id
                },
                new Reparation {
                    DateRep = DateTime.Now.AddDays(-1),
                    Description = "Remplacement écran",
                    TarifMO = 35.00m,
                    TempsMO = 1.5m,
                    DemandeReparationId = demandes[1].Id
                }
            };
            await context.Reparations.AddRangeAsync(reparations);
            await context.SaveChangesAsync();

            // Ajout des Factures
            var factures = new Facture[]
            {
                new Facture {
                    Date = DateTime.Now,
                    MontantTotal = 410.00m,
                    Numero = "FAC-2023-001",
                    ReparationId = reparations[0].Id
                },
                new Facture {
                    Date = DateTime.Now,
                    MontantTotal = 215.00m,
                    Numero = "FAC-2023-002",
                    ReparationId = reparations[1].Id
                }
            };
            await context.Factures.AddRangeAsync(factures);
            await context.SaveChangesAsync();
        }
    }
}
