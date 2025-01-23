using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public string Detalle { get; set; } = null!;
        public List<Medico> medicos { get; set; } = new List<Medico>();

    }
}
