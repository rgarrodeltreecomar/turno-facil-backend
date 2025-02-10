using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Horario
    {
        public Guid  Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public bool Disponible { get; set; } 

        // Relación con Médico
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
    }
}
