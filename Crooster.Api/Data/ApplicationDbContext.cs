using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Crooster.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crooster.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creacion de las configuraciones por default 
            ConfigApp config = new ConfigApp(){
                Id = 1,
                AppName = "Gallos",
                Prefijo = "Local",
            };
            // creación del usuario default
            string password = "admin";
            var data = Encoding.ASCII.GetBytes(password);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            var hashedPassword = new ASCIIEncoding();
            
            AppUser user = new AppUser() {
                Id = 1,
                UserName = "admin",
                Password = hashedPassword.GetString(md5data)
            };

            //lista de parentezcos
            List<Parentezco> parentezcos = new List<Parentezco>() {
                new Parentezco{Id=1,Nombre = "Semental"},
                new Parentezco{Id=2,Nombre = "Gallina"},
                new Parentezco{Id=3,Nombre = "Cría"}
            };

            List<EtapaGallos> etapaGallos = new List<EtapaGallos>() { 
                new EtapaGallos{Id=1,Nombre = "Con la Mamá",IdParentezco = 3 },
            };

            List<EstatusVenta> estatusVentas = new List<EstatusVenta>()
            {
                new EstatusVenta{Id=1,Nombre="Finalizada"},
                new EstatusVenta{Id=2,Nombre="En Proceso"},
                new EstatusVenta{Id=3,Nombre="Cancelada"}
            };

            modelBuilder.Entity<ConfigApp>().HasData(config );
            modelBuilder.Entity<AppUser>().HasData(user);
            modelBuilder.Entity<Parentezco>().HasData(parentezcos);
            modelBuilder.Entity<EtapaGallos>().HasData(etapaGallos);
            modelBuilder.Entity<EstatusVenta>().HasData(estatusVentas);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Parentezco> Parentezcos { get; set; }
        public DbSet<EtapaGallos> EtapaGallos { get; set; }
        public DbSet<EstatusVenta> EstatusVentas { get; set; }
        public DbSet<Gallo> Gallos { get; set; }
        public DbSet<GalloExterno> GalloExternos { get; set; }
        public DbSet<FotosGallos> FotosGallos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<GallosVentas> GallosVentas { get; set; }
        public DbSet<Pago> Pagos { get; set; }

    }
}
