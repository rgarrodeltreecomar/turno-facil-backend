using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTO.Put
{
    public class MedicosPutDTO
    {
        [Required]
        public string IdMedico { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        //public string Password { get; set; } = null!;
        //public int IdRol { get; set; }
        public string IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }
    }
}
