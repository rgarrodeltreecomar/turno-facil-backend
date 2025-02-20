using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.Entities;
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

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] PersonasCreateDTO personasCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                //Validar si el correo ya esta registrado
                bool emailExists = await _context.Personas.AnyAsync(u => u.Email == personasCreateDTO.Email);
                if (emailExists)
                {
                    return BadRequest("El correo ya está registrado.");
                }

                //validar si el rol existe en la DB
                var rol = await _context.Roles.FindAsync(personasCreateDTO.IdRol);
                if (rol == null)
                {
                    return BadRequest("El rol especificado no existe.");
                }

                //Encriptacion de la contraseña

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(personasCreateDTO.Password);

                // Crear un nuevo usuario
                var persona = new Personas
                {
                    IdPersona = personasCreateDTO.IdPersona,
                    Nombre = personasCreateDTO.Nombre,
                    Apellido = personasCreateDTO.Apellido,
                    Email = personasCreateDTO.Email,
                    Password = hashedPassword,
                    IdRol = personasCreateDTO.IdRol
                };

                _context.Personas.Add(persona);
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
    }
}
