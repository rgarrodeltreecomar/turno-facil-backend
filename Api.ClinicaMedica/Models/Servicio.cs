using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Servicio
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        [JsonIgnore]
        public ICollection<PaqueteServicio> Paquetes { get; set; } = new List<PaqueteServicio>();
    }
}
