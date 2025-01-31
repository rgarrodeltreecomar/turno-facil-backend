using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs.Paciente
{
    public class PacienteDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Dni { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public bool ObraSocial { get; set; }
        public bool Activo { get; set; }
    }
}
