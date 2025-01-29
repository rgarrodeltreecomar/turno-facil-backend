using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Medico : Usuario
    {
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; } = null!;
        public decimal? Sueldo { get; set; }
        public bool Activo { get; set; }
        [JsonIgnore]
        public ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();
        [JsonIgnore]
        public ICollection<Horario> Turnos { get; set; } = new List<Horario>();
    }
}
