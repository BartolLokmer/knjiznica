using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knjiznica.Data.Migrations
{
    public partial class KreiranjeBazeSPodatcima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIzlaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SlikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjiga_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mit" },
                    { 2, "Triler" },
                    { 3, "Drama" },
                    { 4, "Vestern" },
                    { 5, "Fantastika" }
                });

            migrationBuilder.InsertData(
                table: "Knjiga",
                columns: new[] { "Id", "Autor", "Cijena", "DatumIzlaska", "KategorijaId", "Naziv", "SlikaUrl" },
                values: new object[,]
                {
                    { 1, "Gillian Flynn", 7.99m, new DateTime(2012, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Gone Girl", "https://www.pluggedin.com/wp-content/uploads/2020/01/gone-girl-cover.jpg" },
                    { 2, "Veronica Roth", 8.99m, new DateTime(2011, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Divergent", "https://upload.wikimedia.org/wikipedia/en/f/f4/Divergent_%28book%29_by_Veronica_Roth_US_Hardcover_2011.jpg" },
                    { 3, "Neil Gaiman", 9.99m, new DateTime(2001, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "American Gods", "https://www.dymocks.com.au/Pages/ImageHandler.ashx?q=9780755322817&w=&h=570" },
                    { 4, "Malcom Gladwell", 12.99m, new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "The Tipping Point", "https://m.media-amazon.com/images/I/61e2z7Nz3rL.jpg" },
                    { 5, "Suzzane Collins", 15.99m, new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "The Hunger Games", "https://m.media-amazon.com/images/I/614SwlZNtJL._AC_UF1000,1000_QL80_.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_KategorijaId",
                table: "Knjiga",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
