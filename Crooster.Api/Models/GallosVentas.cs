using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("GallosVentas")]
    public class GallosVentas
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public Venta Venta { get; set; }
        public int IdGallo { get; set; }
        public Gallo Gallo { get; set; }
    }
}
