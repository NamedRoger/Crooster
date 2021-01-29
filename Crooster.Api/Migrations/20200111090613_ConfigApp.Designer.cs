﻿// <auto-generated />
using System;
using Crooster.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crooster.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200111090613_ConfigApp")]
    partial class ConfigApp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crooster.Models.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("Crooster.Models.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Password = "!#/)zW??C?JJ??",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Crooster.Models.ConfigApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConfigApp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppName = "Gallos",
                            Prefijo = "Local"
                        });
                });

            modelBuilder.Entity("Crooster.Models.EstatusVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstatusVentas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Finalizada"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "En Proceso"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Cancelada"
                        });
                });

            modelBuilder.Entity("Crooster.Models.EtapaGallos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdParentezco")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdParentezco");

                    b.ToTable("EtapasGallos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdParentezco = 3,
                            Nombre = "Con la Mamá"
                        });
                });

            modelBuilder.Entity("Crooster.Models.FotosGallos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GalloId")
                        .HasColumnType("int");

                    b.Property<int>("IdGallo")
                        .HasColumnType("int");

                    b.Property<string>("RutaFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GalloId");

                    b.ToTable("FotosGallos");
                });

            modelBuilder.Entity("Crooster.Models.Gallo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Arete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorPlaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstatusVendido")
                        .HasColumnType("bit");

                    b.Property<bool>("EstatusVida")
                        .HasColumnType("bit");

                    b.Property<int?>("EtapaGallosId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdEtapa")
                        .HasColumnType("int");

                    b.Property<int?>("IdGallina")
                        .HasColumnType("int");

                    b.Property<int>("IdParentezco")
                        .HasColumnType("int");

                    b.Property<int?>("IdSemental")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("Origen")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentezcoId")
                        .HasColumnType("int");

                    b.Property<long>("Placa")
                        .HasColumnType("bigint");

                    b.Property<string>("PlacaEtiqueta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EtapaGallosId");

                    b.HasIndex("ParentezcoId");

                    b.ToTable("Crooster");
                });

            modelBuilder.Entity("Crooster.Models.GalloExterno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAmigo")
                        .HasColumnType("int");

                    b.Property<int>("IdGallo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAmigo");

                    b.HasIndex("IdGallo");

                    b.ToTable("GallosExternos");
                });

            modelBuilder.Entity("Crooster.Models.GallosVentas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GalloId")
                        .HasColumnType("int");

                    b.Property<int>("IdGallo")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<int?>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GalloId");

                    b.HasIndex("VentaId");

                    b.ToTable("GallosVentas");
                });

            modelBuilder.Entity("Crooster.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Crooster.Models.Parentezco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parentezcos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Semental"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Gallina"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Cría"
                        });
                });

            modelBuilder.Entity("Crooster.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmigoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAmigo")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("TipoVenta")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AmigoId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Crooster.Models.EtapaGallos", b =>
                {
                    b.HasOne("Crooster.Models.Parentezco", "Parentezco")
                        .WithMany("EtapaGallos")
                        .HasForeignKey("IdParentezco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crooster.Models.FotosGallos", b =>
                {
                    b.HasOne("Crooster.Models.Gallo", "Gallo")
                        .WithMany("FotosGallos")
                        .HasForeignKey("GalloId");
                });

            modelBuilder.Entity("Crooster.Models.Gallo", b =>
                {
                    b.HasOne("Crooster.Models.EtapaGallos", "EtapaGallos")
                        .WithMany()
                        .HasForeignKey("EtapaGallosId");

                    b.HasOne("Crooster.Models.Parentezco", "Parentezco")
                        .WithMany("Gallos")
                        .HasForeignKey("ParentezcoId");
                });

            modelBuilder.Entity("Crooster.Models.GalloExterno", b =>
                {
                    b.HasOne("Crooster.Models.Amigo", "Amigo")
                        .WithMany("GalloExternos")
                        .HasForeignKey("IdAmigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crooster.Models.Gallo", "Gallo")
                        .WithMany("GalloExternos")
                        .HasForeignKey("IdGallo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crooster.Models.GallosVentas", b =>
                {
                    b.HasOne("Crooster.Models.Gallo", "Gallo")
                        .WithMany("Ventas")
                        .HasForeignKey("GalloId");

                    b.HasOne("Crooster.Models.Venta", "Venta")
                        .WithMany("Gallos")
                        .HasForeignKey("VentaId");
                });

            modelBuilder.Entity("Crooster.Models.Pago", b =>
                {
                    b.HasOne("Crooster.Models.Venta", "Venta")
                        .WithMany("Pagos")
                        .HasForeignKey("VentaId");
                });

            modelBuilder.Entity("Crooster.Models.Venta", b =>
                {
                    b.HasOne("Crooster.Models.Amigo", "Amigo")
                        .WithMany("Ventas")
                        .HasForeignKey("AmigoId");
                });
#pragma warning restore 612, 618
        }
    }
}
