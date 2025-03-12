using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Models;
using Api.ClinicaMedica.Utilities;
using Api.ClinicaMedica.ViewModel;
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

        [HttpPost("register-paciente")]
        public async Task<ActionResult> RegisterPaciente([FromBody] PacienteViewModel pacientesVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Validar si el correo ya está registrado
                bool emailExists = await _context.Usuarios.AnyAsync(u => u.Email == pacientesVM.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                // Encriptación de la contraseña
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pacientesVM.Password);


                var usuario = new Usuarios
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = pacientesVM.Nombre,
                    Apellido = pacientesVM.Apellido,
                    IdRol = 2,
                    Direccion = pacientesVM.Direccion,
                    Email = pacientesVM.Email,
                    Dni = pacientesVM.Dni,
                    FechaRegistro = DateTime.Now,
                    Telefono = pacientesVM.Telefono,
                    PasswordHash = hashedPassword
                };

                var paciente = new Pacientes
                {
                    IdPaciente = pacientesVM.IdPaciente,
                    IdUsuario = usuario.IdUsuario,
                    ObraSocial = pacientesVM.ObraSocial,
                    FechaNacimiento = pacientesVM.FechaNacimiento
                };

                
                // Guardar en la base de datos
                _context.Usuarios.Add(usuario);
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();

                return Ok("Paciente registrado con éxito.");
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

        [HttpPost("register-medico")]
        public async Task<ActionResult> RegisterMedico([FromBody] MedicViewModel medicVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                //Validar si el correo ya esta registrado
                bool emailExists = await _context.Usuarios.AnyAsync(u => u.Email == medicVM.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                
                //Encriptacion de la contraseña

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(medicVM.Password);

                // Crear un nuevo usuario y medico
                var usuario = new Usuarios
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = medicVM.Nombre,
                    Apellido = medicVM.Apellido,
                    Dni = medicVM.Dni,
                    Email = medicVM.Email,
                    Telefono = medicVM.Telefono,
                    IdRol = 1,
                    PasswordHash = hashedPassword,
                    FechaRegistro = DateTime.Now,
                };

                var medico = new Medicos
                {
                    IdMedico = medicVM.IdMedico,
                    IdUsuario = usuario.IdUsuario,
                    IdEspecialidad = medicVM.IdEspecialidad,
                    Sueldo = medicVM.Sueldo,
                                       
                };
                                
                _context.Usuarios.Add(usuario);
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                return Ok("Medico registrado con éxito.");

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

        [HttpPost("register-usuario")]
        public async Task<ActionResult> RegisterUsuario([FromBody] UsuariosCreateDTO usuariosCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                //Validar si el correo ya esta registrado
                bool emailExists = await _context.Usuarios.AnyAsync(u => u.Email == usuariosCreateDTO.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                //validar si el rol existe en la DB
                var rol = await _context.Roles.FindAsync(usuariosCreateDTO.IdRol);
                if (rol == null)
                {
                    return BadRequest("El rol especificado no existe.");
                }

                //Encriptacion de la contraseña

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuariosCreateDTO.Password);

                // Crear un nuevo usuario
                var usuario = new Usuarios
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = usuariosCreateDTO.Nombre,
                    Apellido = usuariosCreateDTO.Apellido,
                    Dni = usuariosCreateDTO.Dni,
                    Email = usuariosCreateDTO.Email,
                    Telefono = usuariosCreateDTO.Telefono,
                    Direccion = usuariosCreateDTO.Direccion,
                    IdRol = usuariosCreateDTO.IdRol,
                    PasswordHash = hashedPassword,
                };

                _context.Usuarios.Add(usuario);
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

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacientesDTO>>> GetPacientes()
        {
            var listaPersonas = await _context.Pacientes.ToListAsync();
            return _mapper.Map<List<PacientesDTO>>(listaPersonas);
        }

        [HttpGet("obtener-medicos")]
        public async Task<ActionResult<IEnumerable<MedicosDTO>>> GetMedicos()
        {
            var listaMedicos = await _context.Pacientes.ToListAsync();
            return _mapper.Map<List<MedicosDTO>>(listaMedicos);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            Usuarios usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
            
            if (usuario == null)
                return NotFound("Usuario inexistente");

            // Obtener la contraseña del objeto dinámico
            string passwordHash = (string)usuario.GetType().GetProperty("PasswordHash")?.GetValue(usuario);

            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, passwordHash))
                return Unauthorized("Contraseña incorrecta");

            // Mapear usuario a RegisteredViewModel
            var usuarioViewModel = new RegisteredViewModel
            {
                Nombre = usuario.GetType().GetProperty("Nombre")?.GetValue(usuario)?.ToString(),
                Apellido = usuario.GetType().GetProperty("Apellido")?.GetValue(usuario)?.ToString(),
                Dni = usuario.GetType().GetProperty("Dni")?.GetValue(usuario)?.ToString(),
                Email = usuario.GetType().GetProperty("Email")?.GetValue(usuario)?.ToString(),
                FechaNacimiento = usuario.GetType().GetProperty("FechaNacimiento")?.GetValue(usuario) as DateTime?,
                Telefono = usuario.GetType().GetProperty("Telefono")?.GetValue(usuario)?.ToString(),
                Direccion = usuario.GetType().GetProperty("Direccion")?.GetValue(usuario)?.ToString(),
                IdRol = usuario.IdRol
            };

            var roles = "";
            switch (usuario.IdRol)
            {
                case 1: roles = "Administrador";
                        break;
                case 2: roles = "Médico";
                    break;
                case 3: roles = "Paciente";
                    break;
            };

            // Generar el token con el rol determinado
            var token = FuncionesToken.GenerarToken(usuarioViewModel, roles, _confi);
            return Ok(token);
        }


    }
}
