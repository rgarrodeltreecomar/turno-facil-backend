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

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerConsultaPorId(string id)
        {
            var consulta = await _context.Consultas
                .Include(c => c.ConsultaServicios)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null)
                return NotFound();

            // Mapea manualmente a DTO para evitar la recursión
            var consultaRespuesta = new ConsultaRespuestaDTO
            {
                IdConsulta = consulta.IdConsulta,
                FechaConsulta = consulta.FechaConsulta,
                HoraConsulta = consulta.HoraConsulta,
                IdPaciente = consulta.IdPaciente,
                NombrePaciente = null, // si querés, podés cargarlo aparte o dejar null
                IdMedico = consulta.IdMedico,
                NombreMedico = null,   // idem
                ObraSocial = consulta.ObraSocial,
                MontoTotal = consulta.MontoTotal,
                Pagado = consulta.Pagado,
                ConsultaServicios = consulta.ConsultaServicios.Select(cs => new ConsultaServicioRespuestaDTO
                {
                    IdServicio = cs.IdServicio,
                    Precio = cs.Precio
                }).ToList()
            };

            return Ok(consultaRespuesta);
        }

        [HttpPost]
        public async Task<IActionResult> CrearConsulta([FromBody] ConsultasCreacionDTO consultaDto)
        {
            if (consultaDto == null || consultaDto.ConsultaServicios == null || consultaDto.ConsultaServicios.Count == 0)
                return BadRequest("Debe enviar al menos un servicio en la consulta.");

            decimal montoBase = consultaDto.ConsultaServicios.Sum(s => s.Precio);

            if (consultaDto.ConsultaServicios.Count > 1)
                montoBase *= 0.85m;

            if (consultaDto.ObraSocial)
                montoBase *= 0.80m;

            var consulta = new Consultas
            {
                IdConsulta = consultaDto.IdConsulta,
                FechaConsulta = consultaDto.FechaConsulta,
                HoraConsulta = consultaDto.HoraConsulta,
                IdPaciente = consultaDto.IdPaciente,
                IdMedico = consultaDto.IdMedico,
                ObraSocial = consultaDto.ObraSocial,
                MontoTotal = montoBase,
                Pagado = consultaDto.Pagado,
                ConsultaServicios = consultaDto.ConsultaServicios.Select(cs => new ConsultaServicio
                {
                    IdServicio = cs.IdServicio,
                    Precio = cs.Precio,
                    IdConsulta = consultaDto.IdConsulta
                }).ToList()
            };

            _context.Consultas.Add(consulta);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al guardar la consulta: {ex.Message}");
            }

            var consultaRespuesta = new ConsultaRespuestaDTO
            {
                IdConsulta = consulta.IdConsulta,
                FechaConsulta = consulta.FechaConsulta,
                HoraConsulta = consulta.HoraConsulta,
                IdPaciente = consulta.IdPaciente,
                NombrePaciente = consultaDto.NombrePaciente,  // Podés obtener del contexto si querés
                IdMedico = consulta.IdMedico,
                NombreMedico = consultaDto.NombreMedico,
                ObraSocial = consulta.ObraSocial,
                MontoTotal = consulta.MontoTotal,
                Pagado = consulta.Pagado,
                ConsultaServicios = consulta.ConsultaServicios.Select(cs => new ConsultaServicioRespuestaDTO
                {
                    IdServicio = cs.IdServicio,
                    Precio = cs.Precio
                }).ToList()
            };

            return CreatedAtAction(nameof(ObtenerConsultaPorId), new { id = consulta.IdConsulta }, consultaRespuesta);
        }

    }
}

