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
using Api.ClinicaMedica.DTO.Put;
using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Update;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class medicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public medicosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosDTO>>> GetMedicos()
        {
            var medicos = await _context.Medicos.Include(m => m.Usuario).ToListAsync();
            var medicosDTO = _mapper.Map<IEnumerable<MedicosDTO>>(medicos);
            return medicosDTO.ToList();
        }

        // GET: api/medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicosDTO>> GetMedicos(string id)
        {
            var medicos = await _context.Medicos.Include(m => m.Usuario).FirstOrDefaultAsync(m => m.IdMedico == id);
            var medicosDTO = _mapper.Map<MedicosDTO>(medicos);

            if (medicos == null)
            {
                return NotFound();
            }

            return medicosDTO;
        }

        // PUT: api/medicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(string id, MedicosUpdateDTO medicosDTO)
        {
            if (id != medicosDTO.IdMedico)
            {
                return BadRequest();
            }

            var idUsuario = (from p in _context.Medicos where p.IdMedico == id select p.IdUsuario).FirstOrDefaultAsync().Result;
            var medico = new Medicos
            {
                IdMedico = medicosDTO.IdMedico,
                IdUsuario = idUsuario,
                FechaNacimiento = medicosDTO.FechaNacimiento,
                IdEspecialidad = medicosDTO.IdEspecialidad,
                Sueldo = medicosDTO.Sueldo
            };

            var usuario = _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == idUsuario).Result;

            usuario.Nombre = medicosDTO.Usuario.Nombre;
            usuario.Apellido = medicosDTO.Usuario.Apellido;
            usuario.Telefono = medicosDTO.Usuario.Telefono;
            usuario.Email = medicosDTO.Usuario.Email;
            usuario.Direccion = medicosDTO.Usuario.Direccion;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Medicos>> PostMedicos(MedicosCreateDTO medicosCreateDTO)
        //{
        //    var medicos = _mapper.Map<Medicos>(medicosCreateDTO);


        //    //_context.Personas.Add(medicos.Persona);
        //    _context.Medicos.Add(medicos);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MedicosExists(medicos.IdMedico))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetMedicos", new { id = medicos.IdMedico }, medicos);
        //}

        // DELETE: api/medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(string id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicosExists(string id)
        {
            return _context.Medicos.Any(e => e.IdMedico == id);
        }
    }
}
