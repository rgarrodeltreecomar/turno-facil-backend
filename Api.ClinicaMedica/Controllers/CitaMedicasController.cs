using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTOs.CitasMedicas;
using Api.ClinicaMedica.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaMedicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CitaMedicasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CitaMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaMedicaGetDTO>>> GetCitasMedicas()
        {
            var citaMedica = await _context.CitasMedicas.Include(p => p.Paciente.Nombre).ToListAsync();
            var citaMedicaDTO = _mapper.Map<List<CitaMedicaGetDTO>>(citaMedica);

            return Ok(citaMedicaDTO);
            
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
