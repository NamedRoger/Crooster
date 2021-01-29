using Microsoft.EntityFrameworkCore.Migrations;

namespace Crooster.Migrations
{
    public partial class foreignkeysexternos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GallosExternos_Amigos_AmigoId",
                table: "GallosExternos");

            migrationBuilder.DropForeignKey(
                name: "FK_GallosExternos_Crooster_GalloId",
                table: "GallosExternos");

            migrationBuilder.DropIndex(
                name: "IX_GallosExternos_AmigoId",
                table: "GallosExternos");

            migrationBuilder.DropIndex(
                name: "IX_GallosExternos_GalloId",
                table: "GallosExternos");

            migrationBuilder.DropColumn(
                name: "AmigoId",
                table: "GallosExternos");

            migrationBuilder.DropColumn(
                name: "GalloId",
                table: "GallosExternos");

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_IdAmigo",
                table: "GallosExternos",
                column: "IdAmigo");

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_IdGallo",
                table: "GallosExternos",
                column: "IdGallo");

            migrationBuilder.AddForeignKey(
                name: "FK_GallosExternos_Amigos_IdAmigo",
                table: "GallosExternos",
                column: "IdAmigo",
                principalTable: "Amigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GallosExternos_Crooster_IdGallo",
                table: "GallosExternos",
                column: "IdGallo",
                principalTable: "Crooster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GallosExternos_Amigos_IdAmigo",
                table: "GallosExternos");

            migrationBuilder.DropForeignKey(
                name: "FK_GallosExternos_Crooster_IdGallo",
                table: "GallosExternos");

            migrationBuilder.DropIndex(
                name: "IX_GallosExternos_IdAmigo",
                table: "GallosExternos");

            migrationBuilder.DropIndex(
                name: "IX_GallosExternos_IdGallo",
                table: "GallosExternos");

            migrationBuilder.AddColumn<int>(
                name: "AmigoId",
                table: "GallosExternos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalloId",
                table: "GallosExternos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_AmigoId",
                table: "GallosExternos",
                column: "AmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_GalloId",
                table: "GallosExternos",
                column: "GalloId");

            migrationBuilder.AddForeignKey(
                name: "FK_GallosExternos_Amigos_AmigoId",
                table: "GallosExternos",
                column: "AmigoId",
                principalTable: "Amigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GallosExternos_Crooster_GalloId",
                table: "GallosExternos",
                column: "GalloId",
                principalTable: "Crooster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
