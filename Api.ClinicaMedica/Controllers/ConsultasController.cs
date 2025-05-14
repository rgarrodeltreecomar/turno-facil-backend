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
using Api.ClinicaMedica.DTO.Basic;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConsultasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CrearConsulta([FromBody] ConsultasCreacionDTO consultasDTO)
        {
            try
            {
                // Mapear el DTO a la entidad Consultas
                var consulta = new Consultas
                {
                    IdConsulta = consultasDTO.IdConsulta,
                    FechaConsulta = consultasDTO.FechaConsulta,
                    HoraConsulta = consultasDTO.HoraConsulta,
                    IdPaciente = consultasDTO.IdPaciente,
                    ObraSocial = consultasDTO.ObraSocial
                };
                var paquetes = _mapper.Map<List<Paquetes>>(consultasDTO.Paquetes);
                _context.Paquetes.AddRange(paquetes);
                _context.Consultas.Add(consulta);
                await _context.SaveChangesAsync();

                // Devolver respuesta exitosa
                return Ok();
            }
            catch (ArgumentException ex)
            {
                // Error de validación (ej: lista de servicios vacía)
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                // Servicio no encontrado
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Error interno del servidor
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
