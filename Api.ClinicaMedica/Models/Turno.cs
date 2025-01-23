namespace Api.ClinicaMedica.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateOnly FechaConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public int medicoId { get; set; }
        public Medico medico { get; set; } = null!;
        public int pacienteId { get; set; }
        public Paciente paciente { get; set; } = null!;
        public List<Servicio> servicios { get; set; } = new List<Servicio>();
        public decimal Precio { get; set; }
        public bool Abonado { get; set; }
    }
}
