using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaMedicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitaMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CitaMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaMedica>>> GetCitasMedicas()
        {
            return await _context.CitasMedicas.ToListAsync();
        }

        // GET: api/CitaMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitaMedica>> GetCitaMedica(int id)
        {
            var citaMedica = await _context.CitasMedicas.FindAsync(id);

            if (citaMedica == null)
            {
                return NotFound();
            }

            return citaMedica;
        }

        // PUT: api/CitaMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitaMedica(int id, CitaMedica citaMedica)
        {
            if (id != citaMedica.Id)
            {
                return BadRequest();
            }

            _context.Entry(citaMedica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaMedicaExists(id))
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

        // POST: api/CitaMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitaMedica>> PostCitaMedica(CitaMedica citaMedica)
        {
            _context.CitasMedicas.Add(citaMedica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitaMedica", new { id = citaMedica.Id }, citaMedica);
        }

        // DELETE: api/CitaMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitaMedica(int id)
        {
            var citaMedica = await _context.CitasMedicas.FindAsync(id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            _context.CitasMedicas.Remove(citaMedica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaMedicaExists(int id)
        {
            return _context.CitasMedicas.Any(e => e.Id == id);
        }
    }
}
