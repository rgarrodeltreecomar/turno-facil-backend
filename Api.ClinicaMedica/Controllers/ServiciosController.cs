﻿using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTO;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.DTO.Put;

using Api.ClinicaMedica.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Api.ClinicaMedica.Controllers
{
    [Route("api/servicios")]
    [ApiController]
    public class serviciosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public serviciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiciosDTO>>> GetServicios()
        {

            var servicio = await _context.Servicios.ToListAsync();
            if (servicio == null || servicio.Count == 0)
            {
                return NotFound("No se encontraron servicios");
            }
            var serviciosDTO = servicio.Select(s => new ServiciosDTO
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Precio = s.Precio
            }).ToList();
            return Ok(serviciosDTO);
        }

        // GET: api/servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiciosDTO>> GetServicios(string id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound("No se encontro un servicio con ese ID");
            }
            var dto = new ServiciosDTO
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Precio = servicio.Precio

            };

            return Ok(dto);
        }

        [HttpGet("medico/{idMedico}")]
        //metodo get para obtener servicios asociados a un medico 
        public async Task<ActionResult<IEnumerable<ServiciosMedicosDTO>>> GetServiciosPorMedico(string idMedico)
        {
            var servicio = await _context.ServiciosMedicos
                .Where(sm => sm.IdMedico == idMedico)
                .Include(sm => sm.Servicio)
                .Include (sm => sm.Medico)
                .ThenInclude(m => m.Usuario)
                .ToListAsync();

            if (!servicio.Any())
            {
                return NotFound("El médico no tiene servicios asociados");
            }

            var serviciosDTO = servicio.Select(sm => new ServiciosMedicosDTO
            {
                IdServicio = sm.IdServicio,
                NombreServicio = sm.Servicio.Nombre,
                IdMedico = sm.IdMedico,
                NombreMedico = sm.Medico.Usuario.Nombre,
                Precio = sm.Precio
                
            }).ToList();
            return Ok(serviciosDTO);
        }

        // PUT: api/servicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicios(string id, ServiciosPutDTO dto)
        {
            if (id != dto.IdServicio)
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo");
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound("Servicio no encontrado");
            }

            servicio.Nombre = dto.Nombre;
            servicio.Descripcion = dto.Descripcion;
            servicio.Precio = dto.Precio;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(dto);
        }

        // POST: api/servicios
        [HttpPost]
        public async Task<ActionResult<ServiciosCreateDTO>> PostServicios(ServiciosCreateDTO dto)
        {
            var servicio = new Servicio
            {
                IdServicio = dto.IdServicio,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio
            };
            _context.Servicios.Add(servicio);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                if (ServiciosExists(servicio.IdServicio))
                {
                    return Conflict("Ya existe un servicio con el mismo ID!");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetServicios), new { id = servicio.IdServicio }, dto);
        }

        // POST: asociar/servicios-medico       
        [HttpPost("asociar-medico")]

        public async Task<IActionResult> PostServicioMedico(ServicioMedicoCreateDTO dto)
        {
            var ExisteServicio = await _context.Servicios.AnyAsync(s => s.IdServicio == dto.IdServicio);
            var ExisteMedico = await _context.Medicos.AnyAsync(m => m.IdMedico == dto.IdMedico);
            if (!ExisteServicio || !ExisteMedico)
            {
                return NotFound("El servicio o el médico no existen");
            }

            var relacion = new ServiciosMedicos
            {
                IdServicio = dto.IdServicio,
                IdMedico = dto.IdMedico,
                Precio = dto.Precio,

            };

            _context.ServiciosMedicos.Add(relacion);
            await _context.SaveChangesAsync();
            return Ok("Servicio asociado al médico correctamente.");
        }

        // DELETE: api/servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicios(string id)
        {
            var servicios = await _context.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiciosExists(string id)
        {
            return _context.Servicios.Any(e => e.IdServicio == id);
        }
    }
}
