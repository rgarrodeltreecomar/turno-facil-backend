using Api.ClinicaMedica.DTOs.Medico;

namespace Api.ClinicaMedica.DTOs.Horario
{
    public class HorarioGetDTO
    {
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public bool Disponible { get; set; }
        public MedicoGetDTO Medico { get; set; }

    }
}
