using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
