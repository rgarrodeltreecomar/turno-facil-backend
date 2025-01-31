using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs.Medico
{
    public class MedicoCreationDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int EspecialidadId { get; set; }
        public decimal? Sueldo { get; set; }
        public bool Activo { get; set; }
    }
}
