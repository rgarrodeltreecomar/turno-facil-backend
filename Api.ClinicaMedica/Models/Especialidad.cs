using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}
