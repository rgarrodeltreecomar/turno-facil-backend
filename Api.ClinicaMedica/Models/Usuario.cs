using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Apellido { get; set; } = null!;
        [Required]
        public string Dni { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public DateOnly FechaNac { get; set; }
        [Required]
        public string Telefono { get; set; } = null!;
        [Required]
        public string Direccion { get; set; } = null!;
    }
}
