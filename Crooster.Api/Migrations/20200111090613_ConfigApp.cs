using Microsoft.EntityFrameworkCore.Migrations;

namespace Crooster.Migrations
{
    public partial class ConfigApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefijo = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigApp", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1L, "!#/)zW??C?JJ??", "admin" });

            migrationBuilder.InsertData(
                table: "ConfigApp",
                columns: new[] { "Id", "AppName", "Prefijo" },
                values: new object[] { 1, "Gallos", "Local" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigApp");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
