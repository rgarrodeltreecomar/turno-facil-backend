using Api.ClinicaMedica.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Paquete
    {
      
        [Key]
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public ICollection<PaqueteServicio> Servicios { get; set; } = new List<PaqueteServicio>();
        public ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();
    }
}