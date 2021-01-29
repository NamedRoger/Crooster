using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("EtapasGallos")]
    public class EtapaGallos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Parentezco")]
        public int IdParentezco { get; set; }
        public Parentezco Parentezco { get; set; }
        public string Descripcion { get; set; }

    }
}
