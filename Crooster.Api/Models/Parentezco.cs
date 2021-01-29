using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("Parentezcos")]
    public class Parentezco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public List<EtapaGallos> EtapaGallos { get; set; }
        public List<Gallo> Gallos { get; set; }



    }
}
