using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class MedicosDTO
    {
        public string IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Password { get; set; } = null!;
        public int IdRol { get; set; }
        public string IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }

        // Relaciones
        public Especialidades? Especialidad { get; set; } // Relación 1 a 1 con Especialidad

        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
