using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crooster.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Prefijo = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parentezcos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentezcos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAmigo = table.Column<int>(nullable: false),
                    AmigoId = table.Column<int>(nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    TipoVenta = table.Column<bool>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Amigos_AmigoId",
                        column: x => x.AmigoId,
                        principalTable: "Amigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EtapasGallos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    IdParentezco = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapasGallos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapasGallos_Parentezcos_IdParentezco",
                        column: x => x.IdParentezco,
                        principalTable: "Parentezcos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(nullable: false),
                    VentaId = table.Column<int>(nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crooster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<long>(nullable: false),
                    Arete = table.Column<string>(nullable: true),
                    Apodo = table.Column<string>(nullable: true),
                    Sexo = table.Column<bool>(nullable: false),
                    Origen = table.Column<bool>(nullable: false),
                    EstatusVida = table.Column<bool>(nullable: false),
                    EstatusVendido = table.Column<bool>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    ColorPlaca = table.Column<string>(nullable: true),
                    Prefijo = table.Column<string>(nullable: true),
                    PlacaEtiqueta = table.Column<string>(nullable: true),
                    FotoPerfil = table.Column<string>(nullable: true),
                    IdGallina = table.Column<int>(nullable: true),
                    IdSemental = table.Column<int>(nullable: true),
                    IdParentezco = table.Column<int>(nullable: false),
                    ParentezcoId = table.Column<int>(nullable: true),
                    IdEtapa = table.Column<int>(nullable: true),
                    EtapaGallosId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crooster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crooster_EtapasGallos_EtapaGallosId",
                        column: x => x.EtapaGallosId,
                        principalTable: "EtapasGallos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crooster_Parentezcos_ParentezcoId",
                        column: x => x.ParentezcoId,
                        principalTable: "Parentezcos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FotosGallos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGallo = table.Column<int>(nullable: false),
                    GalloId = table.Column<int>(nullable: true),
                    RutaFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosGallos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosGallos_Crooster_GalloId",
                        column: x => x.GalloId,
                        principalTable: "Crooster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GallosExternos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAmigo = table.Column<int>(nullable: false),
                    AmigoId = table.Column<int>(nullable: true),
                    IdGallo = table.Column<int>(nullable: false),
                    GalloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallosExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GallosExternos_Amigos_AmigoId",
                        column: x => x.AmigoId,
                        principalTable: "Amigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GallosExternos_Crooster_GalloId",
                        column: x => x.GalloId,
                        principalTable: "Crooster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GallosVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(nullable: false),
                    VentaId = table.Column<int>(nullable: true),
                    IdGallo = table.Column<int>(nullable: false),
                    GalloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallosVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GallosVentas_Crooster_GalloId",
                        column: x => x.GalloId,
                        principalTable: "Crooster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GallosVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EstatusVentas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Finalizada" },
                    { 2, "En Proceso" },
                    { 3, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "Parentezcos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Semental" },
                    { 2, "Gallina" },
                    { 3, "Cría" }
                });

            migrationBuilder.InsertData(
                table: "EtapasGallos",
                columns: new[] { "Id", "Descripcion", "IdParentezco", "Nombre" },
                values: new object[] { 1, null, 3, "Con la Mamá" });

            migrationBuilder.CreateIndex(
                name: "IX_Crooster_EtapaGallosId",
                table: "Crooster",
                column: "EtapaGallosId");

            migrationBuilder.CreateIndex(
                name: "IX_Crooster_ParentezcoId",
                table: "Crooster",
                column: "ParentezcoId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapasGallos_IdParentezco",
                table: "EtapasGallos",
                column: "IdParentezco");

            migrationBuilder.CreateIndex(
                name: "IX_FotosGallos_GalloId",
                table: "FotosGallos",
                column: "GalloId");

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_AmigoId",
                table: "GallosExternos",
                column: "AmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_GallosExternos_GalloId",
                table: "GallosExternos",
                column: "GalloId");

            migrationBuilder.CreateIndex(
                name: "IX_GallosVentas_GalloId",
                table: "GallosVentas",
                column: "GalloId");

            migrationBuilder.CreateIndex(
                name: "IX_GallosVentas_VentaId",
                table: "GallosVentas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_VentaId",
                table: "Pagos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_AmigoId",
                table: "Ventas",
                column: "AmigoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "EstatusVentas");

            migrationBuilder.DropTable(
                name: "FotosGallos");

            migrationBuilder.DropTable(
                name: "GallosExternos");

            migrationBuilder.DropTable(
                name: "GallosVentas");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Crooster");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "EtapasGallos");

            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Parentezcos");
        }
    }
}
