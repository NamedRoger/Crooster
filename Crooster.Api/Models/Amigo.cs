using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("Amigos")]
    public class Amigo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Prefijo { get; set; }
        public bool IsDelete { get; set; } = false;

        public List<GalloExterno> GalloExternos { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
