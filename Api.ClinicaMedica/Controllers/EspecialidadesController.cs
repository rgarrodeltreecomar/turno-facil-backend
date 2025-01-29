using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Models;
using AutoMapper;
using Api.ClinicaMedica.DTOs;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EspecialidadesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Especialidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadGetDTO>>> GetEspecialidades()
        {
            var especialidades = await _context.Especialidades.Include(e => e.Medicos).ToListAsync();

            var especialidadesDto = _mapper.Map<List<EspecialidadGetDTO>>(especialidades);

            return Ok(especialidadesDto);
        }

        // GET: api/Especialidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return especialidad;
        }

        // PUT: api/Especialidads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, EspecialidadCreationDTO especialidadDTO)
        {
            var especialidad = _mapper.Map<Especialidad>(especialidadDTO);

            if (id != especialidad.Id)
            {
                return NotFound(new { mensaje = "La especialidad no existe" });
            }

            _context.Entry(especialidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(id))
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

        // POST: api/Especialidades
        [HttpPost]
        public async Task<ActionResult<Especialidad>> PostEspecialidad(EspecialidadCreationDTO especialidadDTO)
        {
            //Mapear DTO a Especialidad
            var especialidad = _mapper.Map<Especialidad>(especialidadDTO);
            
            //Guardar en BD
            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidad", new { id = especialidad.Id }, especialidad);
        }

        // DELETE: api/Especialidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}
