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
    public class horariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public horariosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horarios>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }

        // GET: api/Horarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horarios>> GetHorarios(string id)
        {
            var horarios = await _context.Horarios.FindAsync(id);

            if (horarios == null)
            {
                return NotFound();
            }

            return horarios;
        }

        // PUT: api/Horarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarios(string id, Horarios horarios)
        {
            if (id != horarios.IdHorario)
            {
                return BadRequest();
            }

            _context.Entry(horarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariosExists(id))
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

        // POST: api/Horarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Horarios>> PostHorarios(HorariosCreateDTO horariosCreateDTO)
        {

            var horarios = _mapper.Map<Horarios>(horariosCreateDTO);
            _context.Horarios.Add(horarios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HorariosExists(horarios.IdHorario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHorarios", new { id = horarios.IdHorario }, horarios);
        }

        // DELETE: api/Horarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarios(string id)
        {
            var horarios = await _context.Horarios.FindAsync(id);
            if (horarios == null)
            {
                return NotFound();
            }

            _context.Horarios.Remove(horarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorariosExists(string id)
        {
            return _context.Horarios.Any(e => e.IdHorario == id);
        }
    }
}
