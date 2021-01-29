using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crooster.Data;
using Crooster.Api.Models;

namespace Crooster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusVentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstatusVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstatusVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstatusVenta>>> GetEstatusVentas()
        {
            return await _context.EstatusVentas.ToListAsync();
        }

        // GET: api/EstatusVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstatusVenta>> GetEstatusVenta(int id)
        {
            var estatusVenta = await _context.EstatusVentas.FindAsync(id);

            if (estatusVenta == null)
            {
                return NotFound();
            }

            return estatusVenta;
        }

        // PUT: api/EstatusVentas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatusVenta(int id, EstatusVenta estatusVenta)
        {
            if (id != estatusVenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(estatusVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstatusVentaExists(id))
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

        // POST: api/EstatusVentas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EstatusVenta>> PostEstatusVenta(EstatusVenta estatusVenta)
        {
            _context.EstatusVentas.Add(estatusVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstatusVenta", new { id = estatusVenta.Id }, estatusVenta);
        }

        // DELETE: api/EstatusVentas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstatusVenta>> DeleteEstatusVenta(int id)
        {
            var estatusVenta = await _context.EstatusVentas.FindAsync(id);
            if (estatusVenta == null)
            {
                return NotFound();
            }

            _context.EstatusVentas.Remove(estatusVenta);
            await _context.SaveChangesAsync();

            return estatusVenta;
        }

        private bool EstatusVentaExists(int id)
        {
            return _context.EstatusVentas.Any(e => e.Id == id);
        }
    }
}
