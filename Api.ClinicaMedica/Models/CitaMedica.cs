using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ClinicaMedica.Models
{
    public class CitaMedica
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public decimal Precio { get; set; }
        public bool Abonado { get; set; }
        //Paciente
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        //Medico
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
        //Paquete
        public int? PaqueteId { get; set; }
        public Paquete Paquete { get; set; } = null!;

    }
}
