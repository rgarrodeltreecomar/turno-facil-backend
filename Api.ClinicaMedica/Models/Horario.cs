using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public bool Disponible { get; set; } // Indica si el turno está disponible para reservar

        // Relación con Médico
        [JsonIgnore]
        public int MedicoId { get; set; }
        [JsonIgnore]
        public Medico Medico { get; set; } = null!;
    }
}
