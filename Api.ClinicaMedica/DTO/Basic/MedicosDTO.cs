using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class MedicosDTO
    {
        public string IdMedico { get; set; }
        public string IdPersona { get; set; }
        public string IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }

        // Relaciones
        public PersonasDTO? Persona { get; set; } // Relación 1 a 1 con Persona
        public Especialidades? Especialidad { get; set; } // Relación 1 a 1 con Especialidad
    }
}
