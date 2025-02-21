using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _confi;

        public RegisterController(ApplicationDbContext context, IMapper mapper, IConfiguration confi)
        {
            _context = context;
            _mapper = mapper;
            _confi = confi;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO.IdRol == 1) // Administrador
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
                if (usuario == null)
                    return NotFound("Usuario Inexistente");

                if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, usuario.Password))
                    return Unauthorized("Contraseña incorrecta");

                var token = FuncionesToken.GenerarToken(loginDTO, _confi);
                return Ok(token);
            }
            else if (loginDTO.IdRol == 2) // Médico
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
                if (medico == null)
                    return NotFound("Médico Inexistente");

                if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, medico.Password))
                    return Unauthorized("Contraseña incorrecta");

                var token = FuncionesToken.GenerarToken(loginDTO, _confi);
                return Ok(token);
            }
            else if (loginDTO.IdRol == 3) // Paciente
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
                if (paciente == null)
                    return NotFound("Paciente Inexistente");

                if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, paciente.Password))
                    return Unauthorized("Contraseña incorrecta");

                var token = FuncionesToken.GenerarToken(loginDTO, _confi);
                return Ok(token);
            }
            else
            {
                return NotFound("Rol inexistente");
            }
        }
                
    }
}
