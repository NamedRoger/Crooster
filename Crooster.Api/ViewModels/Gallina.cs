using Crooster.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crooster.Api.ViewModels
{
    public class AddGallina
    {
        public int Id { get; set; }
        [Required]
        public long Placa { get; set; }
        public string Arete { get; set; }
        public string Apodo { get; set; }
        public bool EstatusVendido { get; set; }
        public bool EstatusVida { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public int IdParentezco { get; set; }
        public bool Origen { get; set; }
        public bool Sexo { get; set; }
        public int? IdAmigo { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string ColorPlaca { get; set; }
    }
}