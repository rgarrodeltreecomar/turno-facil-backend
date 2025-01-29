using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Paciente : Usuario
    {
        public bool ObraSocial { get; set; }
        public bool Activo { get; set; }
        [JsonIgnore]
        public ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();

    }
}
