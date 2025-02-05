using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.ClinicaMedica.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public string? Dni { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        [Required]
        public string Password { get; set; } = null!;

        public int RolId { get; set; }

        public Rol Rol { get; set; } = null!; 
    }
}
