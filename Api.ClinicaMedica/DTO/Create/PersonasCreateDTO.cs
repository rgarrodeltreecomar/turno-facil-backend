using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTO.Create
{
    public class PersonasCreateDTO
    {
        [Required]
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Rol { get; set; }
    }
}
