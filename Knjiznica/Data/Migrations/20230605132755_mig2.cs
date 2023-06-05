using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knjiznica.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Kategorija_KategorijaId",
                table: "Knjiga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga");

            migrationBuilder.RenameTable(
                name: "Knjiga",
                newName: "Knjige");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_KategorijaId",
                table: "Knjige",
                newName: "IX_Knjige_KategorijaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Kategorija_KategorijaId",
                table: "Knjige",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Kategorija_KategorijaId",
                table: "Knjige");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige");

            migrationBuilder.RenameTable(
                name: "Knjige",
                newName: "Knjiga");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_KategorijaId",
                table: "Knjiga",
                newName: "IX_Knjiga_KategorijaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Kategorija_KategorijaId",
                table: "Knjiga",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
