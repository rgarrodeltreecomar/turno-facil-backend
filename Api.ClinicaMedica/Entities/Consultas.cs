using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Consultas
    {
        [Key]
        public string IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public string IdPaciente { get; set; }
        public string IdMedico { get; set; }
        public string? IdServicio { get; set; }
        public string? IdPaquete { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagado { get; set; }
        public Pacientes? Paciente { get; set; }
        public Medicos? Medico { get; set; }
        public Servicios? Servicio { get; set; }
        public Paquetes? Paquete { get; set; }
       

    }
}
