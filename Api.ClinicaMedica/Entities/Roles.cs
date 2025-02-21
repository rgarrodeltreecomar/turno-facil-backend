using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [MaxLength(50)] // Limita el nombre del rol a 50 caracteres
        public string Nombre { get; set; } = string.Empty;

    }
}
