using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs
{
    public class TurnoCreationDTO
    {
        public DateOnly FechaConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public int medicoId { get; set; }
        public MedicBasicDTO medico { get; set; } = null!;
        public int pacienteId { get; set; }
        public PacienteCreationDTO paciente { get; set; } = null!;
        public List<ServicioCreationDTO> servicios { get; set; } = new List<ServicioCreationDTO>();
        public decimal Precio { get; set; }
        public bool Abonado { get; set; }
    }
}
