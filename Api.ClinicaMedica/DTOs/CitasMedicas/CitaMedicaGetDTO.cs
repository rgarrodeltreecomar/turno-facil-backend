using Api.ClinicaMedica.DTOs.Medico;
using Api.ClinicaMedica.DTOs.Paciente;
using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs.CitasMedicas
{
    public class CitaMedicaGetDTO
    {
        public DateTime FechaConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public decimal Precio { get; set; }
        public bool Abonado { get; set; }
        //Paciente
        public PacienteDTO Paciente { get; set; } = null!;
        //Medico
        public MedicoCitaMedicaDTO Medico { get; set; } = null!;
        //Paquete
        public int? PaqueteId { get; set; }
        public Paquete Paquete { get; set; } = null!;
    }
}
