using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.Entities
{
    public class Personas
    {
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Password { get; set; } = null!;
        public int IdRol { get; set; }

        // Relaciones
        public Roles? Rol { get; set; }
        public Pacientes? Paciente { get; set; } // Relación 1 a 1 con Paciente
        public Medicos? Medico { get; set; } // Relación 1 a 1 con Medico
    }
}
