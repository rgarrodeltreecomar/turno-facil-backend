
namespace Api.ClinicaMedica.Entities
{
    public class Medicos
    {
        public string IdMedico { get; set; }
        
        public Guid IdUsuario { get; set; }
        
        public string? IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        // Relaciones Propiedad de Navegacion
        public Usuarios Usuario { get; set; }
        public Especialidades Especialidad { get; set; } = null!; // Relación 1 a 1 con Especialidad

        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
