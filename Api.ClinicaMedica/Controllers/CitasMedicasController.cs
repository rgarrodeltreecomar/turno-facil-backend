using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Entities;
using AutoMapper;
using Api.ClinicaMedica.DTO.Create;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasMedicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CitasMedicasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CitasMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasMedicas>>> GetCitasMedicas()
        {
            return await _context.CitasMedicas.Include(c => c.Paciente).Include(c => c.Medico).Include(c => c.Servicio)
                                .Include(c => c.DetallesServicios).ToListAsync();
        }

        // GET: api/CitasMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitasMedicas>> GetCitasMedicas(string id)
        {
            var citasMedicas = await _context.CitasMedicas.Include(c => c.Paciente).Include(c=> c.Servicio)
                                .Include(c=>c.Medico)
                                .Include(c => c.DetallesServicios).FirstOrDefaultAsync(c => c.IdCitas == id);

            if (citasMedicas == null)
            {
                return NotFound();
            }
                        
            return citasMedicas;
        }

        // PUT: api/CitasMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitasMedicas(string id, CitasMedicas citasMedicas)
        {
            if (id != citasMedicas.IdCitas)
            {
                return BadRequest();
            }

            _context.Entry(citasMedicas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasMedicasExists(id))
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

        // POST: api/CitasMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitasMedicas>> PostCitasMedicas(CitasMedicasCreacionDTO citasMedicasDTO)
        {
            var citasMedicas = _mapper.Map<CitasMedicas>(citasMedicasDTO);
            var detallesNoTracking = _context.DetalleServicios
                                        .AsNoTracking()
                                        .Where(d => d.IdCitas == citasMedicas.IdCitas)
                                        .ToList();

            try
            {
                _context.ChangeTracker.Clear(); // 🔥 Limpia el rastreo antes de agregar
                
                _context.CitasMedicas.Add(citasMedicas);
                _context.DetalleServicios.AddRange(detallesNoTracking);
                             
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CitasMedicasExists(citasMedicas.IdCitas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetCitasMedicas", new { id = citasMedicas.IdCitas }, citasMedicas);
        }

        // DELETE: api/CitasMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitasMedicas(string id)
        {
            var citasMedicas = await _context.CitasMedicas.FindAsync(id);
            if (citasMedicas == null)
            {
                return NotFound();
            }

            _context.CitasMedicas.Remove(citasMedicas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitasMedicasExists(string id)
        {
            return _context.CitasMedicas.Any(e => e.IdCitas == id);
        }
    }
}
