using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.DTO.Create;
using AutoMapper;

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

        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidades>>> GetEspecialidades()
        {
            return await _context.Especialidades.ToListAsync();
        }

        // GET: api/Especialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidades>> GetEspecialidades(string id)
        {
            var especialidades = await _context.Especialidades.FindAsync(id);

            if (especialidades == null)
            {
                return NotFound();
            }

            return especialidades;
        }

        // PUT: api/Especialidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidades(string id, Especialidades especialidades)
        {
            if (id != especialidades.IdEspecialidad)
            {
                return BadRequest();
            }

            _context.Entry(especialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadesExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especialidades>> PostEspecialidades(EspecialidadesCreateDTO especialidadesCreateDTO)
        {
            var especialidades = _mapper.Map<Especialidades>(especialidadesCreateDTO);
            _context.Especialidades.Add(especialidades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EspecialidadesExists(especialidades.IdEspecialidad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEspecialidades", new { id = especialidades.IdEspecialidad }, especialidades);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidades(string id)
        {
            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadesExists(string id)
        {
            return _context.Especialidades.Any(e => e.IdEspecialidad == id);
        }
    }
}
