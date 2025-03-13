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
    public class facturacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public facturacionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Facturacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturacion>>> GetFacturaciones()
        {
            return await _context.Facturaciones.Include(f => f.Consulta).ToListAsync();
        }

        // GET: api/Facturacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturacion>> GetFacturacion(string id)
        {
            var facturacion = await _context.Facturaciones.Include(f => f.Consulta).FirstOrDefaultAsync(f => f.IdFactura == id);

            if (facturacion == null)
            {
                return NotFound();
            }

            return facturacion;
        }

        // PUT: api/Facturacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturacion(string id, FacturacionCreateDTO facturacionDTO)
        {
            var facturacion = _mapper.Map<Facturacion>(facturacionDTO);
            if (id != facturacion.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(facturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturacionExists(id))
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

        // POST: api/Facturacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facturacion>> PostFacturacion(FacturacionCreateDTO facturacionDTO)
        {
            var facturacion = _mapper.Map<Facturacion>(facturacionDTO);
            _context.Facturaciones.Add(facturacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturacionExists(facturacion.IdFactura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacturacion", new { id = facturacion.IdFactura }, facturacion);
        }

        // DELETE: api/Facturacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturacion(string id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return NotFound();
            }

            _context.Facturaciones.Remove(facturacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturacionExists(string id)
        {
            return _context.Facturaciones.Any(e => e.IdFactura == id);
        }
    }
}
