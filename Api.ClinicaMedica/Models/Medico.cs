using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        public Usuario medico { get; set; } = null!;
        public int especialidadId { get; set; }
        public Especialidad especialidad { get; set; } = null!;
        public List<Turno> turnos { get; set; } = new List<Turno>();
        public List<Horario> horarios { get; set; } = new List<Horario>();
        public decimal Sueldo { get; set; }
        public bool Activo { get; set; }
    }
}
