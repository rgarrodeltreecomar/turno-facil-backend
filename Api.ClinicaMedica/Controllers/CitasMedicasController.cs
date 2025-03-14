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
    [Route("api/cita-medicas")]
    [ApiController]
    public class citasmedicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public citasmedicasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/citasmedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasMedicas>>> GetCitasMedicas()
        {
            return await _context.CitasMedicas.Include(c => c.Paciente).Include(c => c.Medico).Include(c => c.Servicio)
                                .Include(c => c.DetallesServicios).ToListAsync();
        }

        // GET: api/citasmedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitasMedicas>> GetCitasMedicas(string id)
        {
            var citasMedicas = await _context.CitasMedicas.Include(c => c.Paciente).Include(c => c.Medico).Include(c => c.Servicio)
                                .Include(c => c.DetallesServicios).FirstOrDefaultAsync(c => c.IdCitas == id);

            if (citasMedicas == null)
            {
                return NotFound();
            }
                        
            return citasMedicas;
        }

        // PUT: api/citasmedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitasMedicas(string id, CitasMedicas citasMedicas)
        {

            var citaM = await _context.CitasMedicas.Include(dc => dc.DetallesServicios)
                            .FirstOrDefaultAsync(cm => cm.IdCitas == id);

            if (citaM == null) { return NotFound(); }

            try
            {
                citaM.IdCitas = citasMedicas.IdCitas;
                citaM.IdMedico = citasMedicas.IdMedico;
                citaM.IdPaciente = citasMedicas.IdPaciente;
                citaM.IdServicio = citasMedicas.IdServicio;
                citaM.FechaConsulta = citasMedicas.FechaConsulta;
                citaM.HoraConsulta = citasMedicas.HoraConsulta;
                citaM.MontoTotal = citasMedicas.MontoTotal;
                citaM.PagadoONo = citasMedicas.PagadoONo;

                _context.DetalleServicios.RemoveRange(citasMedicas.DetallesServicios);
                _context.CitasMedicas.Update(citaM);
                _context.DetalleServicios.AddRange(citasMedicas.DetallesServicios);
                
                await _context.SaveChangesAsync();  

                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
             
        }

        // POST: api/citasmedicas
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

        // DELETE: api/citasmedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitasMedicas(string id)
        {
            var citasMedicas = await _context.CitasMedicas.Include(c => c.DetallesServicios).FirstOrDefaultAsync(c => c.IdCitas == id);

            if (citasMedicas == null)
            {
                return NotFound();
            }

            _context.DetalleServicios.RemoveRange(citasMedicas.DetallesServicios);
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
