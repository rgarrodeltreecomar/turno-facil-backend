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
using Api.ClinicaMedica.Servicios;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaServicio _consultaServicio;

        // Inyectar el servicio en el constructor
        public ConsultaController(ConsultaServicio consultaServicio)
        {
            _consultaServicio = consultaServicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearConsulta([FromBody] ConsultasCreacionDTO consultasDTO)
        {
            try
            {
                // Mapear el DTO a la entidad Consultas
                var consulta = new Consultas
                {
                    FechaConsulta = consultasDTO.FechaConsulta,
                    HoraConsulta = consultasDTO.HoraConsulta,
                    IdPaciente = consultasDTO.IdPaciente,
                    IdMedico = consultasDTO.IdMedico,
                    ObraSocial = consultasDTO.ObraSocial
                };

                // Llamar al servicio para crear la consulta
                var resultado = await _consultaServicio.CrearConsultasAsync(consulta, consultasDTO.ServiciosId);

                // Devolver respuesta exitosa
                return Ok(resultado);
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
