using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.Entities
{
    public class Medicos
    {
        public string IdMedico { get; set; }
        public string IdPersona { get; set; }
        public string IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }

        // Relaciones
        public Personas Persona { get; set; } // Relación 1 a 1 con Persona
        public Especialidades Especialidad { get; set; } // Relación 1 a 1 con Especialidad

        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
