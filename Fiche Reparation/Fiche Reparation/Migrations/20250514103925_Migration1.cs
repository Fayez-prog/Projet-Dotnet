using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiche_Reparation.Migrations
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
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandeReparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDepotAppareil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Appareil = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SymptomesPanne = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeReparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeReparations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandeReparations_ClientId",
                table: "DemandeReparations",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandeReparations");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
