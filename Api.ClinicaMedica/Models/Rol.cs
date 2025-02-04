using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Rol
    
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] // Limita el nombre del rol a 50 caracteres
        public string Nombre { get; set; } = string.Empty;

        // Relación con Usuario
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();


    }
}
