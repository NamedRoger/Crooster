using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public Venta Venta { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}
