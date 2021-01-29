using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("Ventas")]
    public class Venta
    {
        public int Id { get; set; }
        public int IdAmigo { get; set; }
        public Amigo Amigo { get; set; }
        public decimal Monto { get; set; }
        public bool TipoVenta { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        public List<GallosVentas> Gallos { get; set; }
        public List<Pago> Pagos { get; set; }

    }
}
