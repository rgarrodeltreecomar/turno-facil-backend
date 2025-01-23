using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public Usuario paciente { get; set; } = null!;
        public bool ObraSocial { get; set; }
        public bool Activo { get; set; }

    }
}
