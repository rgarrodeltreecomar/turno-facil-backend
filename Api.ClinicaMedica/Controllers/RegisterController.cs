﻿using Api.ClinicaMedica.AccesoDatos;
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

        [HttpPost("register-paciente")]
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
                    Dni = pacientesCreateDTO.Dni,
                    Email = pacientesCreateDTO.Email,
                    FechaNacimiento = pacientesCreateDTO.FechaNacimiento,
                    Telefono = pacientesCreateDTO.Telefono,
                    Direccion = pacientesCreateDTO.Direccion,
                    Password = hashedPassword,
                    IdRol = pacientesCreateDTO.IdRol,
                    ObraSocial = pacientesCreateDTO.ObraSocial
                };

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
                    Nombre = medicosCreateDTO.Nombre,
                    Apellido = medicosCreateDTO.Apellido,
                    Dni = medicosCreateDTO.Dni,
                    Email = medicosCreateDTO.Email,
                    FechaNacimiento = medicosCreateDTO.FechaNacimiento,
                    Telefono = medicosCreateDTO.Telefono,
                    Direccion = medicosCreateDTO.Direccion,
                    IdRol = medicosCreateDTO.IdRol,
                    IdEspecialidad = medicosCreateDTO.IdEspecialidad,
                    Password = hashedPassword,
                    Sueldo = medicosCreateDTO.Sueldo
                };

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
                    IdUsuario = usuariosCreateDTO.IdUsuario,
                    Nombre = usuariosCreateDTO.Nombre,
                    Apellido = usuariosCreateDTO.Apellido,
                    Dni = usuariosCreateDTO.Dni,
                    Email = usuariosCreateDTO.Email,
                    FechaNacimiento = usuariosCreateDTO.FechaNacimiento,
                    Telefono = usuariosCreateDTO.Telefono,
                    Direccion = usuariosCreateDTO.Direccion,
                    IdRol = usuariosCreateDTO.IdRol,
                    Password = hashedPassword,
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

        // GET: api/Pacientes
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
