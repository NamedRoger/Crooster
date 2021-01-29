using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("FotosGallos")]
    public class FotosGallos
    {
        public int Id { get; set; }
        public int IdGallo { get; set; }
        public Gallo Gallo { get; set; }
        public string RutaFoto { get; set; }
    }
}
