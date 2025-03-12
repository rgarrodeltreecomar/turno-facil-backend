using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.ViewModel
{
    public class PacienteViewModel
    {
        [Required]
        public string IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        [Required]
        public string Email { get; set; }  // Unique
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Password { get; set; }
        public decimal? Sueldo { get; set; }
        public bool ObraSocial { get; set; }    
    }
}
