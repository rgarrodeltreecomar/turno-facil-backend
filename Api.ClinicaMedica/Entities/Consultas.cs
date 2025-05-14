using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Consultas
    {
        public string IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }

        public string? IdPaciente { get; set; }

        public decimal MontoTotal { get; set; }
        public bool Pagado { get; set; }
        public bool ObraSocial { get; set; }

        public Pacientes? Paciente { get; set; }
        public ICollection<Paquetes> Paquetes { get; set; }


    }
}
