using CodeFirst.Contexts;
using CodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ManteleriaDbContext _context;

        public EventosController(ManteleriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Eventos
                .Include(e => e.DetallesManteleria)
                .ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Eventos
                .Include(e => e.DetallesManteleria)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Eventos/search?term=ana
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Evento>>> SearchEventos([FromQuery] string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return await _context.Eventos.ToListAsync();
            }

            var eventos = await _context.Eventos
                .Where(e => e.Nombre.Contains(term) ||
                           e.ClienteNombre.Contains(term) ||
                           e.Descripcion != null && e.Descripcion.Contains(term) ||
                           e.ClienteEmail.Contains(term))
                .ToListAsync();

            return eventos;
        }

        // GET: api/Eventos/estado/Confirmado
        [HttpGet("estado/{estado}")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventosPorEstado(string estado)
        {
            var eventos = await _context.Eventos
                .Where(e => e.Estado == estado)
                .ToListAsync();

            return eventos;
        }

        // PUT: api/Eventos/5/confirmar
        [HttpPut("{id}/confirmar")]
        public async Task<IActionResult> ConfirmarEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            evento.Estado = "Confirmado";
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Eventos/5/cancelar
        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> CancelarEvento(int id, [FromBody] string motivo)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            evento.Estado = "Cancelado";
            // Podrías agregar un campo para el motivo si lo necesitas
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
