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
    public class PaquetesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaquetesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paquetes>>> GetPaquetes()
        {
            return await _context.Paquetes.ToListAsync();
        }

        // GET: api/Paquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paquetes>> GetPaquetes(string id)
        {
            var paquetes = await _context.Paquetes.FindAsync(id);

            if (paquetes == null)
            {
                return NotFound();
            }

            return paquetes;
        }

        // PUT: api/Paquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaquetes(string id, PaquetesCreateDTO paquetesDTO)
        {
            var paquetes = _mapper.Map<Paquetes>(paquetesDTO);
            if (id != paquetes.CodigoPaquete)
            {
                return BadRequest();
            }

            _context.Entry(paquetes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaquetesExists(id))
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

        // POST: api/Paquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paquetes>> PostPaquetes(PaquetesCreateDTO paquetesDTO)
        {
            var paquetes = _mapper.Map<Paquetes>(paquetesDTO);
            _context.Paquetes.Add(paquetes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaquetesExists(paquetes.CodigoPaquete))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaquetes", new { id = paquetes.CodigoPaquete }, paquetes);
        }

        // DELETE: api/Paquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaquetes(string id)
        {
            var paquetes = await _context.Paquetes.FindAsync(id);
            if (paquetes == null)
            {
                return NotFound();
            }

            _context.Paquetes.Remove(paquetes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaquetesExists(string id)
        {
            return _context.Paquetes.Any(e => e.CodigoPaquete == id);
        }
    }
}
