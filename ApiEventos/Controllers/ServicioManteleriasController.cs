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
    public class ServicioManteleriasController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public ServicioManteleriasController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/ServicioMantelerias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioManteleria>>> GetServiciosManteleria()
        {
            return await _context.ServiciosManteleria.ToListAsync();
        }

        // GET: api/ServicioMantelerias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioManteleria>> GetServicioManteleria(int id)
        {
            var servicioManteleria = await _context.ServiciosManteleria.FindAsync(id);

            if (servicioManteleria == null)
            {
                return NotFound();
            }

            return servicioManteleria;
        }

        // PUT: api/ServicioMantelerias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioManteleria(int id, ServicioManteleria servicioManteleria)
        {
            if (id != servicioManteleria.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioManteleria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioManteleriaExists(id))
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

        // POST: api/ServicioMantelerias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicioManteleria>> PostServicioManteleria(ServicioManteleria servicioManteleria)
        {
            _context.ServiciosManteleria.Add(servicioManteleria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioManteleria", new { id = servicioManteleria.Id }, servicioManteleria);
        }

        // DELETE: api/ServicioMantelerias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioManteleria(int id)
        {
            var servicioManteleria = await _context.ServiciosManteleria.FindAsync(id);
            if (servicioManteleria == null)
            {
                return NotFound();
            }

            _context.ServiciosManteleria.Remove(servicioManteleria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioManteleriaExists(int id)
        {
            return _context.ServiciosManteleria.Any(e => e.Id == id);
        }
    }
}
