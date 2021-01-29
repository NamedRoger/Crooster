using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("EstatusVentas")]
    public class EstatusVenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
