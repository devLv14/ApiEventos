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
    public class AnimacionsController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public AnimacionsController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Animacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animacion>>> GetAnimaciones()
        {
            return await _context.Animaciones.ToListAsync();
        }

        // GET: api/Animacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animacion>> GetAnimacion(int id)
        {
            var animacion = await _context.Animaciones.FindAsync(id);

            if (animacion == null)
            {
                return NotFound();
            }

            return animacion;
        }

        // PUT: api/Animacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimacion(int id, Animacion animacion)
        {
            if (id != animacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(animacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimacionExists(id))
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

        // POST: api/Animacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animacion>> PostAnimacion(Animacion animacion)
        {
            _context.Animaciones.Add(animacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimacion", new { id = animacion.Id }, animacion);
        }

        // DELETE: api/Animacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimacion(int id)
        {
            var animacion = await _context.Animaciones.FindAsync(id);
            if (animacion == null)
            {
                return NotFound();
            }

            _context.Animaciones.Remove(animacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimacionExists(int id)
        {
            return _context.Animaciones.Any(e => e.Id == id);
        }
    }
}
