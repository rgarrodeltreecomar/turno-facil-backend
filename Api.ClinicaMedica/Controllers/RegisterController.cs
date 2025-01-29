using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Models;
using Api.ClinicaMedica.DTOs.DtoLogin;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

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

        //// GET: api/Register
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        //{
        //    return await _context.Usuarios.ToListAsync();
        //}

        //// GET: api/Register/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuario(int id)
        //{
        //    var usuario = await _context.Usuarios.FindAsync(id);

        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuario;
        //}

        //// PUT: api/Register/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        //{
        //    if (id != usuario.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(usuario).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDTOs registerDTOs)
        {
            if (!ModelState.IsValid) 
            {
             return BadRequest(ModelState);
            
            }

            //Validar si el correo ya esta registrado
            if (_context.Usuarios.Any(u => u.Email == registerDTOs.Email)) 
            {
                return BadRequest("El correo ya esta registrado");            
            
            }
            //Encriptacion de la contraseña

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDTOs.Password);

            // Crear un nuevo usuario
            var usuario = new Usuario
            {
                Email = registerDTOs.Email,
                Password = hashedPassword
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario registrado con éxito.");
        }

        //    // DELETE: api/Register/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteUsuario(int id)
        //    {
        //        var usuario = await _context.Usuarios.FindAsync(id);
        //        if (usuario == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Usuarios.Remove(usuario);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool UsuarioExists(int id)
        //    {
        //        return _context.Usuarios.Any(e => e.Id == id);
        //    }
    }
}
