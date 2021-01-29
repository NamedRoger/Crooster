using Crooster.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.ViewModels
{
    public class ViewVenta : Venta
    {
        public new List<Gallo> Gallos { get; set; }
        public decimal Pago { get; set; }
    }
}
