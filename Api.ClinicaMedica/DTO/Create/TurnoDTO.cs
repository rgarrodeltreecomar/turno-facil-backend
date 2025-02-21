using Api.ClinicaMedica.Entities;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.DTO.Create
{
    public class TurnoDTO
    {
        public string IdTurno { get; set; }
        public string IdHorario { get; set; }
        public string IdMedico { get; set; }

        public DateTime Fecha { get; set; }

        public bool Asistencia { get; set; }
       
        [JsonIgnore]
        public string? IdPaciente { get; set; }
        public string Estado { get; set; }
    }
}
