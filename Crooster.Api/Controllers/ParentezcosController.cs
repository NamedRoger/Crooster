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
    public class ParentezcosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParentezcosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parentezcoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parentezco>>> GetParentezcos()
        {
            return await _context.Parentezcos.ToListAsync();
        }

        // GET: api/Parentezcoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parentezco>> GetParentezco(int id)
        {
            var parentezco = await _context.Parentezcos.FindAsync(id);

            if (parentezco == null)
            {
                return NotFound();
            }

            return parentezco;
        }

        // PUT: api/Parentezcoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentezco(int id, Parentezco parentezco)
        {
            if (id != parentezco.Id)
            {
                return BadRequest();
            }

            _context.Entry(parentezco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentezcoExists(id))
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

        // POST: api/Parentezcoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Parentezco>> PostParentezco(Parentezco parentezco)
        {
            _context.Parentezcos.Add(parentezco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParentezco", new { id = parentezco.Id }, parentezco);
        }

        // DELETE: api/Parentezcoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parentezco>> DeleteParentezco(int id)
        {
            var parentezco = await _context.Parentezcos.FindAsync(id);
            if (parentezco == null)
            {
                return NotFound();
            }

            _context.Parentezcos.Remove(parentezco);
            await _context.SaveChangesAsync();

            return parentezco;
        }

        private bool ParentezcoExists(int id)
        {
            return _context.Parentezcos.Any(e => e.Id == id);
        }
    }
}
