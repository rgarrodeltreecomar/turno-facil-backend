﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteServiciosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaqueteServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaqueteServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaqueteServicio>>> GetPaqueteServicios()
        {
            return await _context.PaqueteServicios.ToListAsync();
        }

        // GET: api/PaqueteServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaqueteServicio>> GetPaqueteServicio(string id)
        {
            var paqueteServicio = await _context.PaqueteServicios.FindAsync(id);

            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return paqueteServicio;
        }

        // PUT: api/PaqueteServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaqueteServicio(string id, PaqueteServicio paqueteServicio)
        {
            if (id != paqueteServicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(paqueteServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaqueteServicioExists(id))
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

        // POST: api/PaqueteServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaqueteServicio>> PostPaqueteServicio(PaqueteServicio paqueteServicio)
        {
            _context.PaqueteServicios.Add(paqueteServicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaqueteServicioExists(paqueteServicio.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaqueteServicio", new { id = paqueteServicio.Id }, paqueteServicio);
        }

        // DELETE: api/PaqueteServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaqueteServicio(string id)
        {
            var paqueteServicio = await _context.PaqueteServicios.FindAsync(id);
            if (paqueteServicio == null)
            {
                return NotFound();
            }

            _context.PaqueteServicios.Remove(paqueteServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaqueteServicioExists(string id)
        {
            return _context.PaqueteServicios.Any(e => e.Id == id);
        }
    }
}
