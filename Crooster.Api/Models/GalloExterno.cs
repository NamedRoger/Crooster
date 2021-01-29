using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.Models
{
    [Table("GallosExternos")]
    public class GalloExterno
    {
        public int Id { get; set; }
        [ForeignKey("Amigo")]
        public int IdAmigo { get; set; }
        public Amigo Amigo { get; set; }
        [ForeignKey("Gallo")]
        public int IdGallo { get; set; }
        public Gallo Gallo { get; set; }
    }
}
