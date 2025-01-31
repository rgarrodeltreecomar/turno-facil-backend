using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public bool Disponible { get; set; } 

        // Relación con Médico
        public int MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
    }
}
