using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using AutoMapper;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pacientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public pacientesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacientesDTO>>> GetPacientes()
        {
            var listaPacientes = await _context.Pacientes.Include(p => p.Usuario).ToListAsync();
            return _mapper.Map<List<PacientesDTO>>(listaPacientes);
        }

        // GET: api/pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacientesDTO>> GetPacientes(string id)
        {
            var pacientes = await _context.Pacientes.Include(p => p.Usuario).FirstOrDefaultAsync(p => p.IdPaciente == id);

            var pacienteDTO = _mapper.Map<PacientesDTO>(pacientes);
            if (pacientes == null)
            {
                return NotFound();
            }

            return pacienteDTO;
        }

        // PUT: api/pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacientes(string id, Pacientes pacientes)
        {
            if (id != pacientes.IdPaciente)
            {
                return BadRequest();
            }

            _context.Entry(pacientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientesExists(id))
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

        // POST: api/pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Pacientes>> PostPacientes(PacientesCreateDTO pacientesCreateDTO)
        //{

        //    var paciente = _mapper.Map<Pacientes>(pacientesCreateDTO);

        //    //_context.Personas.Add(paciente.Persona);
        //    _context.Pacientes.Add(paciente);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PacientesExists(paciente.IdPaciente))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPacientes", new { id = paciente.IdPaciente }, paciente);
        //}

        // DELETE: api/pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacientes(string id)
        {
            var pacientes = await _context.Pacientes.FindAsync(id);
            if (pacientes == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(pacientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientesExists(string id)
        {
            return _context.Pacientes.Any(e => e.IdPaciente == id);
        }
    }
}
