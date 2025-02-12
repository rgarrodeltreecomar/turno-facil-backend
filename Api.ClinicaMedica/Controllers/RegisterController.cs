using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.CodeAnalysis.Scripting;
using Api.ClinicaMedica.DTOs.DtoRegister;

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

        // GET: api/Register
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
          .Select(u => new UsuarioDTO
          {
              Id = u.Id.ToString(),
              Nombre = u.Nombre,
              Apellido = u.Apellido,
              Email = u.Email,
              Rol = u.Rol
          })
          .ToListAsync();

            return Ok(usuarios);

        }

        // GET: api/Register/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id.ToString(),
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Rol = usuario.Rol
            };

            return Ok(usuarioDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UserUpdate(Guid id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nombre = usuarioUpdateDTO.Nombre;
            usuario.Apellido = usuarioUpdateDTO.Apellido;
            usuario.Email = usuarioUpdateDTO.Email;
            usuario.Rol = usuarioUpdateDTO.Rol;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Usuario actualizado correctamente.");
        }



        [HttpPost]
public async Task<ActionResult> RegisterUser([FromBody] RegisterDTOs registerDTOs)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        // Validar si el correo ya está registrado
        bool emailExists = await _context.Usuarios.AnyAsync(u => u.Email == registerDTOs.Email);
        if (emailExists)
        {
            return BadRequest("El correo ya está registrado.");
        }

        // Encriptación de la contraseña
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDTOs.Password);
        Console.WriteLine($"Contraseña Original: {registerDTOs.Password}");
        Console.WriteLine($"Contraseña Hasheada: {hashedPassword}");

        // Crear un nuevo usuario
        var usuario = new Usuario
        {
            Nombre = registerDTOs.Nombre,
            Apellido = registerDTOs.Apellido,
            Email = registerDTOs.Email,
            Password = hashedPassword,
            Rol = registerDTOs.Rol  // Asignar el rol directamente desde el DTO
        };

        // Agregar el usuario a la base de datos
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


        // DELETE: api/Register/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}


