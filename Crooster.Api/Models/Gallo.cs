using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("Crooster")]
    public class Gallo
    {
        public int Id { get; set; }
        public long Placa { get; set; }
        public string Arete { get; set; }
        public string Apodo { get; set; }
        public bool Sexo { get; set; } = true;
        public bool Origen { get; set; } = true;
        public bool EstatusVida { get; set; } = true;
        public bool EstatusVendido { get; set; } = false;
        public DateTime FechaNacimiento { get; set; }
        public string ColorPlaca { get; set; }
        public string Prefijo { get; set; }
        public string PlacaEtiqueta { get => $"{Prefijo}-{Placa}"; }
        public string FotoPerfil { get; set; }
        public int? IdGallina { get; set; }
        public int? IdSemental { get; set; }
        public int IdParentezco { get; set; }
        public Parentezco Parentezco { get; set; }
        public int? IdEtapa { get; set; }
        public EtapaGallos EtapaGallos { get; set; }
        public bool IsDelete { get; set; }
        

        public List<FotosGallos> FotosGallos { get; set; }
        public List<GalloExterno> GalloExternos { get; set; }
        public List<GallosVentas> Ventas { get; set; }
    }
}
