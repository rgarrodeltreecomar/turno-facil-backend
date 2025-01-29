using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
<<<<<<< HEAD
        [Required]
        public string Dni { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public DateOnly FechaNac { get; set; }
        [Required]
        public string Telefono { get; set; } = null!;
        [Required]
        public string Direccion { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
=======
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
>>>>>>> 2977e3be1c7caaeec82cd2288bfd4a38816cf144
    }
}
