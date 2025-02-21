using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegisterController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("register-medico")]
        public async Task<ActionResult> RegisterPaciente([FromBody] PacientesCreateDTO pacientesCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                //Validar si el correo ya esta registrado
                bool emailExists = await _context.Pacientes.AnyAsync(u => u.Email == pacientesCreateDTO.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                //validar si el rol existe en la DB
                var rol = await _context.Roles.FindAsync(pacientesCreateDTO.IdRol);
                if (rol == null)
                {
                    return BadRequest("El rol especificado no existe.");
                }

                //Encriptacion de la contraseña

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pacientesCreateDTO.Password);

                // Crear un nuevo usuario
                var paciente = new Pacientes
                {
                    IdPaciente = pacientesCreateDTO.IdPaciente,
                    Nombre = pacientesCreateDTO.Nombre,
                    Apellido = pacientesCreateDTO.Apellido,
                    Email = pacientesCreateDTO.Email,
                    Password = hashedPassword,
                    IdRol = pacientesCreateDTO.IdRol
                };

                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();

                return Ok("Usuario registrado con éxito.");

            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                return StatusCode(500, $"Error al guardar en la base de datos: {innerException}");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado. " + ex.Message);
            }
        }

        [HttpPost("register-paciente")]
        public async Task<ActionResult> RegisterMedico([FromBody] MedicosCreateDTO medicosCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                //Validar si el correo ya esta registrado
                bool emailExists = await _context.Medicos.AnyAsync(u => u.Email == medicosCreateDTO.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                //validar si el rol existe en la DB
                var rol = await _context.Roles.FindAsync(medicosCreateDTO.IdRol);
                if (rol == null)
                {
                    return BadRequest("El rol especificado no existe.");
                }

                //Encriptacion de la contraseña

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(medicosCreateDTO.Password);

                // Crear un nuevo usuario
                var medico = new Medicos
                {
                    IdMedico = medicosCreateDTO.IdMedico,
                    IdEspecialidad = medicosCreateDTO.IdEspecialidad,
                    Nombre = medicosCreateDTO.Nombre,
                    Apellido = medicosCreateDTO.Apellido,
                    Email = medicosCreateDTO.Email,
                    Password = hashedPassword,
                    IdRol = medicosCreateDTO.IdRol
                };

                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                return Ok("Usuario registrado con éxito.");

            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                return StatusCode(500, $"Error al guardar en la base de datos: {innerException}");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado. " + ex.Message);
            }
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacientesDTO>>> GetPacientes()
        {
            var listaPersonas = await _context.Pacientes.ToListAsync();
            return _mapper.Map<List<PacientesDTO>>(listaPersonas);
        }

    }
}
