using Crooster.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.ViewModels
{
    public class AddCria
    {
        public int Id { get; set; }
        public int IdParentezco { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Cantidad { get; set; }
        public int IdSemental { get; set; }
        public int IdGallina { get; set; }
        public bool EstatusVida { get; set; }
        public bool EstatusVendido { get; set; }
        public bool Origen { get; set; }
        public string ColorPlaca { get; set; }
    }
    public class ViewCria
    {
        public int Id { get; set; }
        public long Placa { get; set; }
        public string Arete { get; set; }
        public string Apodo { get; set; }
        public bool Sexo { get; set; }
        public bool EstatusVida { get; set; }
        public EtapaGallos Etapa { get; set; }
        public Gallo Semental { get; set; }
        public Gallo Gallina { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FotoPerfil { get; set; }


        public static ViewCria llenarCria(Gallo cria)
        {
            return new ViewCria()
            {
                Id = cria.Id,
                Placa = cria.Placa,
                Arete = cria.Arete,
                Apodo = cria.Apodo,
                FechaNacimiento = cria.FechaNacimiento,
                Sexo = cria.Sexo,
                EstatusVida = cria.EstatusVida,
                FotoPerfil = cria.FotoPerfil,
                Etapa = cria.EtapaGallos
            };
        }
    }
}
