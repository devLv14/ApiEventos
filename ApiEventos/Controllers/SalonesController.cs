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
    public class SalonesController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public SalonesController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Salones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalones()
        {
            return await _context.Salones.ToListAsync();
        }

        // GET: api/Salones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _context.Salones.FindAsync(id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        // PUT: api/Salones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon(int id, Salon salon)
        {
            if (id != salon.Id)
            {
                return BadRequest();
            }

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        // POST: api/Salones
        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon(Salon salon)
        {
            _context.Salones.Add(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.Id }, salon);
        }

        // DELETE: api/Salones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var salon = await _context.Salones.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salones.Remove(salon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Salones/search?term=bodas
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Salon>>> SearchSalones([FromQuery] string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return await _context.Salones.ToListAsync();
            }

            var salones = await _context.Salones
                .Where(s => s.Nombre.Contains(term) ||
                           s.Descripcion != null && s.Descripcion.Contains(term) ||
                           s.Ubicacion.Contains(term) ||
                           s.TipoEvento.Contains(term))
                .ToListAsync();

            return salones;
        }

        private bool SalonExists(int id)
        {
            return _context.Salones.Any(e => e.Id == id);
        }
    }
}
