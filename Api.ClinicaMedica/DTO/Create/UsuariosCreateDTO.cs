using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Create
{
    public class UsuariosCreateDTO
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string Email { get; set; }  // Unique
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Password { get; set; } = null!;
        public int IdRol { get; set; }
                
    }
}
