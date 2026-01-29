using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Contexts;
using CodeFirst.Models;

namespace ApiEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecoracionsController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public DecoracionsController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Decoracions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Decoracion>>> GetDecoraciones()
        {
            return await _context.Decoraciones.ToListAsync();
        }

        // GET: api/Decoracions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Decoracion>> GetDecoracion(int id)
        {
            var decoracion = await _context.Decoraciones.FindAsync(id);

            if (decoracion == null)
            {
                return NotFound();
            }

            return decoracion;
        }

        // PUT: api/Decoracions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDecoracion(int id, Decoracion decoracion)
        {
            if (id != decoracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(decoracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DecoracionExists(id))
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

        // POST: api/Decoracions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Decoracion>> PostDecoracion(Decoracion decoracion)
        {
            _context.Decoraciones.Add(decoracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDecoracion", new { id = decoracion.Id }, decoracion);
        }

        // DELETE: api/Decoracions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDecoracion(int id)
        {
            var decoracion = await _context.Decoraciones.FindAsync(id);
            if (decoracion == null)
            {
                return NotFound();
            }

            _context.Decoraciones.Remove(decoracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DecoracionExists(int id)
        {
            return _context.Decoraciones.Any(e => e.Id == id);
        }
    }
}
