using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Clientele.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarif = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePieces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appareils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appareils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appareils_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiecesRecharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixTTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixAChat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypePieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiecesRecharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiecesRecharge_TypePieces_TypePieceId",
                        column: x => x.TypePieceId,
                        principalTable: "TypePieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DemandesReparation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDepotAppareil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePrevueRep = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SymptomesPanne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppareilId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesReparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandesReparation_Appareils_AppareilId",
                        column: x => x.AppareilId,
                        principalTable: "Appareils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DemandesReparation_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRep = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifMO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempsMO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DemandeReparationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparations_DemandesReparation_DemandeReparationId",
                        column: x => x.DemandeReparationId,
                        principalTable: "DemandesReparation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReparationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Reparations_ReparationId",
                        column: x => x.ReparationId,
                        principalTable: "Reparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appareils_ClientId",
                table: "Appareils",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appareils_NumeroSerie",
                table: "Appareils",
                column: "NumeroSerie",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_NumTel",
                table: "Clients",
                column: "NumTel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DemandesReparation_AppareilId",
                table: "DemandesReparation",
                column: "AppareilId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandesReparation_ClientId",
                table: "DemandesReparation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_Numero",
                table: "Factures",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ReparationId",
                table: "Factures",
                column: "ReparationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PiecesRecharge_TypePieceId",
                table: "PiecesRecharge",
                column: "TypePieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_DemandeReparationId",
                table: "Reparations",
                column: "DemandeReparationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "PiecesRecharge");

            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "TypePieces");

            migrationBuilder.DropTable(
                name: "DemandesReparation");

            migrationBuilder.DropTable(
                name: "Appareils");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
