using Crooster.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.ViewModels
{
    public class AddGallo : Gallo
    {
        public int? IdAmigo { get; set; }
        public int Cantidad { get; set; } = 1;
        public IFormFile FileFotoPerfil { get; set; }

        public static Gallo VaciarGallo(AddGallo gallo)
        {
            return new Gallo()
            {
                Placa = gallo.Placa,
                Arete = gallo.Arete,
                Apodo = gallo.Apodo,
                ColorPlaca = gallo.ColorPlaca,
                EstatusVendido = gallo.EstatusVendido,
                EstatusVida = gallo.EstatusVida,
                IdEtapa = gallo.IdEtapa,
                FechaNacimiento = gallo.FechaNacimiento,
                IdGallina = gallo.IdGallina,
                IdSemental = gallo.IdSemental,
                IdParentezco = gallo.IdParentezco,
                Sexo = gallo.Sexo,
                Origen = gallo.Origen,
                Prefijo = gallo.Prefijo,
            };
        }
    }
}
