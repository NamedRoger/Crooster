using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crooster.Data;
using Crooster.Api.Models;
using Crooster.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crooster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GallosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GallosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gallo>>> GetGallos()
        {
            return await context.Gallos.Where(g => g.IsDelete == false && g.EstatusVendido == false)
                                       .ToListAsync();
        }

        //Obtener los gallos dependiendo de su parentezco 
        //Se pasa el id del parentezco y se redirecciona al método
        [HttpGet("{parentezco}")]
        public async Task<ActionResult<object>> GetGallosByParentezco(string parentezco)
        {
            parentezco.ToLower();
            if (parentezco == "semental")
            {
                var sementales = await Sementales();
                return Ok(sementales);
            }
            if (parentezco == "gallina")
            {
                var gallinas = await Gallinas();
                return Ok(gallinas);
            }
            if (parentezco == "cria")
            {
                var crias = await Crias();
                return Ok(crias);
            }

            return BadRequest();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Gallo>> GetGallo(int id){
            Gallo gallo = await context.Gallos.FindAsync(id);
            if(gallo == null){
                return NotFound();
            }

            return gallo;
        }

        [HttpGet("{id:int}/{parentezco}")]
        public async Task<ActionResult<object>> GetGalloById(int id, string parentezco)
        {
            Gallo gallo = await context.Gallos.FindAsync(id);
            if (gallo != null)
            {
                if (parentezco == "semental")
                {
                    return await Semental(gallo);
                }
                if (parentezco == "gallina")
                {

                }
                if (parentezco == "cria")
                {

                }
            }

            return NotFound();
        }

        //Insertar nuevo gallo a la base de datos
        [HttpPost]
        [Route("semental")]
        public async Task<ActionResult<Gallo>> AddSemental([FromBody]AddSemental semental)
        {
            if (semental != null)
            {
                //se llena el objeto gallo 
                Gallo gallo = new Gallo()
                {
                    Apodo = semental.Apodo,
                    Placa = semental.Placa,
                    ColorPlaca = semental.ColorPlaca,
                    EstatusVendido = semental.EstatusVendido,
                    EstatusVida = semental.EstatusVida,
                    FechaNacimiento = semental.FechaNacimiento,
                    IdParentezco = semental.IdParentezco,
                    Origen = semental.Origen,
                    Sexo = semental.Sexo,
                };
                if(gallo.Origen)
                {
                    gallo.Prefijo = "Local";
                }

                //se inserta el objeto gallo 
                
                if (!gallo.Origen)
                {
                    Amigo amigo = context.Amigos.Find(semental.IdAmigo);
                    gallo.Prefijo = amigo.Prefijo;
                    GalloExterno galloExterno = new GalloExterno()
                    {
                        Amigo = amigo,
                        Gallo = gallo
                    };

                    await context.AddAsync<GalloExterno>(galloExterno);
                }
                await context.AddAsync<Gallo>(gallo);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetGallo", new { id = gallo.Id }, gallo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("gallina")]
        public async Task<ActionResult<Gallo>> AddGallina([FromBody]AddGallina gallina)
        {
            if (gallina != null)
            {
                //se llena el objeto gallo 
                Gallo gallo = new Gallo()
                {
                    Apodo = gallina.Apodo,
                    Placa = gallina.Placa,
                    Arete = gallina.Arete,
                    ColorPlaca = gallina.ColorPlaca,
                    EstatusVendido = gallina.EstatusVendido,
                    EstatusVida = gallina.EstatusVida,
                    FechaNacimiento = gallina.FechaNacimiento,
                    IdParentezco = gallina.IdParentezco,
                    Origen = gallina.Origen,
                    Sexo = gallina.Sexo,
                };

                //se inserta el objeto gallo 
                await context.AddAsync<Gallo>(gallo);
                if (!gallo.Origen)
                {
                    Amigo amigo = context.Amigos.Find(gallina.IdAmigo);
                    GalloExterno galloExterno = new GalloExterno()
                    {
                        Amigo = amigo,
                        Gallo = gallo
                    };

                    await context.AddAsync<GalloExterno>(galloExterno);
                }

                await context.SaveChangesAsync();
                return CreatedAtAction("GetGallo", new { id = gallo.Id }, gallo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("cria")]
        public async Task<ActionResult<ViewCria>> AddCria(AddCria galloNuevo)
        {
            if (galloNuevo != null)
            {
                 List<Gallo> nuevasCrias = new List<Gallo>();
                 Parentezco parentezco = await context.Parentezcos.FirstOrDefaultAsync(p => p.Nombre == "Cría");
                long nuevaPlaca;
                for (int i = 0; i < galloNuevo.Cantidad; i++)
                {
                     var galloAnterior = await context.Gallos.OrderByDescending(g => g.Placa).FirstAsync();
                     nuevaPlaca = galloAnterior.Placa + 1;
                     nuevasCrias.Add(new Gallo()
                    {
                        Placa = nuevaPlaca,
                        IdGallina = galloNuevo.IdGallina,
                        IdSemental = galloNuevo.IdSemental,
                        Parentezco = parentezco
                    });
                 }
                 await context.AddRangeAsync(nuevasCrias);
                 await context.SaveChangesAsync();


                return Ok(galloNuevo);
            }
            return BadRequest();
        }

        //eliminar gallo
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> DelteGallo(int id)
        {
            Gallo gallo = await context.Gallos.FindAsync(id);
            if (gallo == null)
            {
                return NotFound();
            }

            gallo.IsDelete = true;
            context.Entry(gallo).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return gallo;
        }
        //buscar gallos con el parentezco de semental
        public async Task<List<Gallo>> Sementales()
        {
            return await context.Gallos.Where(s => s.IsDelete == false)
                                           .Where(s => s.IdParentezco == 1)
                                           .Where(s => s.EstatusVendido == false)
                                           .Include(s => s.Parentezco)
                                           .Include(s => s.GalloExternos)
                                           .ThenInclude(gs => gs.Amigo)
                                           .ToListAsync();
        }

        public async Task<ViewSemental> Semental(Gallo gallo) {
            var semental = new ViewSemental(){
                Id = gallo.Id,
                Apodo = gallo.Apodo,
                ColorPlaca = gallo.ColorPlaca,
                EstatusVendido = gallo.EstatusVendido,
                EstatusVida = gallo.EstatusVida,
                EtapaGallos = gallo.EtapaGallos,
                IdEtapa = gallo.IdEtapa,
                FechaNacimiento = gallo.FechaNacimiento,
                IdParentezco = gallo.IdParentezco,
                Placa = gallo.Placa,
                Sexo = gallo.Sexo,
                Origen = gallo.Origen,
                IsDelete = gallo.IsDelete,
                Prefijo = gallo.Prefijo,
                Parentezco = gallo.Parentezco,
                FotosGallos = gallo.FotosGallos
            };

            List<Gallo> hijos = await  context.Gallos.Where(h => h.IdSemental == gallo.Id).ToListAsync();
            semental.Hijos = hijos;

            return semental;
        }

        //buscar gallos con el parentezco gallina
        public async Task<List<Gallo>> Gallinas()
        {
            return await context.Gallos.Where(s => s.IsDelete == false)
                                           .Where(s => s.EstatusVendido == false)
                                           .Where(s => s.IdParentezco == 2)
                                           .Include(s => s.Parentezco)
                                           .ToListAsync();
        }

        //buscar gallos con el parentezco de cria
        public async Task<List<ViewCria>> Crias()
        {
            List<ViewCria> viewCrias = new List<ViewCria>();
            var crias = await context.Gallos.Where(s => s.IsDelete == false)
                                           .Where(s => s.EstatusVendido == false)
                                           .Where(s => s.IdParentezco == 3)
                                           .Include(s => s.Parentezco)
                                           .ToListAsync();
            foreach (var cria in crias)
            {
                var semental = await context.Gallos.FirstOrDefaultAsync(s => s.Id == cria.IdSemental);
                var gallina = await context.Gallos.FirstOrDefaultAsync(s => s.Id == cria.IdGallina);

                var viewCria = ViewCria.llenarCria(cria);
                viewCria.Semental = semental;
                viewCria.Gallina = gallina;

                viewCrias.Add(viewCria);
            }

            return viewCrias;
        }
    }
}