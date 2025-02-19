using Api.ClinicaMedica.DTOs.Paciente;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class PersonasDTO
    {
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Rol { get; set; }

        // Relaciones
        public PacientesDTO? Paciente { get; set; } // Relación 1 a 1 con Paciente
        public MedicosDTO? Medico { get; set; } // Relación 1 a 1 con Medico
    }
}
