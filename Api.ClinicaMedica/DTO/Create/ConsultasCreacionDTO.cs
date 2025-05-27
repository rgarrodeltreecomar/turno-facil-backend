using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Create
{
    public class ConsultasCreacionDTO
    {
        public string IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }

        public string? IdPaciente { get; set; }
        public string? NombrePaciente { get; set; } // opcional, para mostrar

        public string IdMedico { get; set; }
        public string NombreMedico { get; set; } // opcional, para mostrar

        public bool ObraSocial { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagado { get; set; }

        public List<ConsultaServicio> ConsultaServicios { get; set; } = new List<ConsultaServicio>();

    }
}
