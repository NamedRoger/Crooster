using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crooster.Data;
using Crooster.Api.Models;

namespace Crooster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapaGallosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtapaGallosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EtapaGallos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtapaGallos>>> GetEtapaGallos()
        {
            return await _context.EtapaGallos.Include(e => e.Parentezco).ToListAsync();
        }

        // GET: api/EtapaGallos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtapaGallos>> GetEtapaGallos(int id)
        {
            var etapaGallos = await _context.EtapaGallos.FindAsync(id);

            if (etapaGallos == null)
            {
                return NotFound();
            }

            return etapaGallos;
        }

        // PUT: api/EtapaGallos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtapaGallos(int id, EtapaGallos etapaGallos)
        {
            if (id != etapaGallos.Id)
            {
                return BadRequest();
            }

            _context.Entry(etapaGallos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapaGallosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EtapaGallos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EtapaGallos>> PostEtapaGallos(EtapaGallos etapaGallos)
        {
            _context.EtapaGallos.Add(etapaGallos);
            await _context.SaveChangesAsync();
            Parentezco parentezco = await _context.Parentezcos.FindAsync(etapaGallos.IdParentezco);
            etapaGallos.Parentezco = parentezco;
            
            return CreatedAtAction("GetEtapaGallos", new { id = etapaGallos.Id }, etapaGallos);
        }

        // DELETE: api/EtapaGallos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EtapaGallos>> DeleteEtapaGallos(int id)
        {
            var etapaGallos = await _context.EtapaGallos.FindAsync(id);
            if (etapaGallos == null)
            {
                return NotFound();
            }

            _context.EtapaGallos.Remove(etapaGallos);
            await _context.SaveChangesAsync();

            return etapaGallos;
        }

        private bool EtapaGallosExists(int id)
        {
            return _context.EtapaGallos.Any(e => e.Id == id);
        }
    }
}
