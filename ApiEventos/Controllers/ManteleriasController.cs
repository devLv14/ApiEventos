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
    public class ManteleriasController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public ManteleriasController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Mantelerias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manteleria>>> GetMantelerias()
        {
            return await _context.Mantelerias.ToListAsync();
        }

        // GET: api/Mantelerias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manteleria>> GetManteleria(int id)
        {
            var manteleria = await _context.Mantelerias.FindAsync(id);

            if (manteleria == null)
            {
                return NotFound();
            }

            return manteleria;
        }

        // PUT: api/Mantelerias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManteleria(int id, Manteleria manteleria)
        {
            if (id != manteleria.Id)
            {
                return BadRequest();
            }

            _context.Entry(manteleria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManteleriaExists(id))
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

        // POST: api/Mantelerias
        [HttpPost]
        public async Task<ActionResult<Manteleria>> PostManteleria(Manteleria manteleria)
        {
            _context.Mantelerias.Add(manteleria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManteleria", new { id = manteleria.Id }, manteleria);
        }

        // DELETE: api/Mantelerias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManteleria(int id)
        {
            var manteleria = await _context.Mantelerias.FindAsync(id);
            if (manteleria == null)
            {
                return NotFound();
            }

            _context.Mantelerias.Remove(manteleria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Mantelerias/search?term=rojo
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Manteleria>>> SearchMantelerias([FromQuery] string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return await _context.Mantelerias.ToListAsync();
            }

            var mantelerias = await _context.Mantelerias
                .Where(m => m.Nombre.Contains(term) ||
                           m.Color.Contains(term) ||
                           m.Material.Contains(term))
                .ToListAsync();

            return mantelerias;
        }

        private bool ManteleriaExists(int id)
        {
            return _context.Mantelerias.Any(e => e.Id == id);
        }
    }
}
