using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Consultas
    {
        [Key]
        public string IdConsulta { get; set; }

        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }

        public string? IdPaciente { get; set; }
        public Pacientes? Paciente { get; set; }

        public string IdMedico { get; set; }
        public Medicos Medico { get; set; }       // navegación al médico

        public bool ObraSocial { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagado { get; set; }

        // ← aquí reemplazamos tu colección de paquetes por la de servicios
        public ICollection<ConsultaServicio> ConsultaServicios { get; set; } = new List<ConsultaServicio>();

    }
}
