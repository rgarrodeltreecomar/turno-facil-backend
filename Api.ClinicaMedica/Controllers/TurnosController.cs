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

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/turnos/disponibles
        // Este endpoint devuelve solo los turnos que están disponibles
        [HttpGet("disponibles")]
        public async Task<IActionResult> ObtenerTurnosDisponibles()
        {
            var turnosDisponibles = await _context.Turnos
            .Where(t => t.Estado == "Disponible")  // Filtrar solo los turnos disponibles
            .Include(t => t.Horario)
            .Include(t => t.Medico)
            .OrderBy(t => t.Fecha)
            .ThenBy(t => t.Horario.HorarioInicio)  // Ordenar por fecha y hora
            .ToListAsync();


            var turnosDTO = turnosDisponibles.Select(t => new TurnoDTO
            {
                IdTurno = t.IdTurno,
                IdHorario = t.IdHorario,
                IdMedico = t.IdMedico,
                Fecha = t.Fecha,
                Asistencia = t.Asistencia,
                IdPaciente = t.IdPaciente,
                Estado = t.Estado,
            }).ToList();

            return Ok(turnosDTO);
        }


        // GET: api/turnos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTurnoPorId(string id)

        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("El ID del turno no puede estar vacio");



            var turno = await _context.Turnos
                .Include(t => t.Horario)
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(t => t.IdTurno == id);

            if (turno == null)
                return NotFound($"No se encontró el turno con ID {id}");

            return Ok(turno);
        }

        // PUT: api/turnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTurno(string id, Turnos turnoActualizado)
        {
            if (string.IsNullOrWhiteSpace(id) || id != turnoActualizado.IdTurno)
                return BadRequest("El ID del turno no es válido o no coincide.");

            var turnoExistente = await _context.Turnos.FindAsync(id);
            if (turnoExistente == null)
                return NotFound($"No se encontró el turno con ID {id}");

            // Actualizar los valores
            turnoExistente.IdHorario = turnoActualizado.IdHorario;
            turnoExistente.IdMedico = turnoActualizado.IdMedico;
            turnoExistente.IdPaciente = turnoActualizado.IdPaciente;
            turnoExistente.Fecha = turnoActualizado.Fecha;
            turnoExistente.Estado = turnoActualizado.Estado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnosExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok("Turno actualizado correctamente.");
        }

        // POST: api/turnos/crear
        // Este endpoint es para que el administrador cree los turnos
        [HttpPost("crear")]
        public async Task<ActionResult<TurnoDTO>> CrearTurno([FromBody] TurnoDTO turnoDTO)
        {
            // Validar que el IdHorario existe en la base de datos
            var horario = await _context.Horarios.FindAsync(turnoDTO.IdHorario);
            if (horario == null)
                return BadRequest("El horario seleccionado no es válido.");

            // Validar que no exista ya un turno para el mismo médico, fecha y franja horaria
            bool turnoExistente = await _context.Turnos.AnyAsync(t => t.IdHorario == turnoDTO.IdHorario &&
                                                                      t.IdMedico == turnoDTO.IdMedico &&
                                                                      t.Fecha.Date == turnoDTO.Fecha.Date);

            if (turnoExistente)
                return BadRequest("Ya existe un turno asignado para este médico en esa franja horaria y fecha.");

            // Convertir DTO a entidad Turnos para persistir en la base de datos
            var turno = new Turnos
            {
                IdTurno = turnoDTO.IdTurno,
                IdHorario = turnoDTO.IdHorario,
                IdMedico = turnoDTO.IdMedico,
                Fecha = turnoDTO.Fecha,
                Asistencia = turnoDTO.Asistencia, //por defecto
                IdPaciente = turnoDTO.IdPaciente,
                Estado = "Disponible"
            };

            // Agregar el nuevo turno a la base de datos
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            // Devolver el turno creado (usando DTO)
            return Ok(turnoDTO);
        }

        // POST: api/turnos/reservar
        // Este endpoint permite que un paciente reserve un turno
        [HttpPost("reservar")]
        public async Task<IActionResult> ReservarTurno([FromBody] ReservaTurnoDTO reserva)
        {
            // Buscar el turno con el IdTurno proporcionado
            var turno = await _context.Turnos.FirstOrDefaultAsync(t => t.IdTurno == reserva.IdTurno);

            if (turno == null)
                return NotFound("El turno no existe.");

            if (turno.Estado == "Ocupado")
                return BadRequest("El turno ya está ocupado.");

            // Si el turno está disponible, actualizar su estado y asignar el paciente
            turno.Estado = "Ocupado";  // Cambiar estado a "Ocupado"
            turno.IdPaciente = reserva.IdPaciente;  // Asignar paciente al turno

            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();

            return Ok("Turno reservado con éxito.");
        }

        [HttpPost("cancelar")]
        public async Task<IActionResult> CancelarTurno([FromBody] CancelarTurnoDTO cancelacion)
        {
            var turno = await _context.Turnos.FirstOrDefaultAsync(t => t.IdTurno == cancelacion.IdTurno);

            if (turno == null)
                return NotFound("El turno no existe.");

            if (turno.Estado == "Disponible")
                return BadRequest("El turno ya está disponible, no necesita ser cancelado.");

            turno.Estado = "Disponible"; // Volver a estado disponible
            turno.IdPaciente = null; // Quitar la asignación del paciente

            await _context.SaveChangesAsync();
            return Ok("Turno cancelado y ahora está disponible.");
        }


        // DELETE: api/turnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTurno(string id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
                return NotFound($"No se encontró el turno con ID {id}");

            try
            {
                _context.Turnos.Remove(turno);
                await _context.SaveChangesAsync();
                return Ok("Turno eliminado correctamente.");
            }
            catch (DbUpdateException)
            {
                return BadRequest("No se puede eliminar el turno porque tiene dependencias.");
            }
        }

        private bool TurnosExists(string id)
        {
            return _context.Turnos.Any(e => e.IdTurno == id);
        }
    }
}
