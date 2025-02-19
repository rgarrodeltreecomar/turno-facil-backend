namespace Api.ClinicaMedica.Entities
{
    public class Pacientes
    {
        public string IdPaciente { get; set; }
        public string IdPersona { get; set; }
        public bool ObraSocial { get; set; }

        // Relación 1 a 1 con Persona
        public Personas Persona { get; set; }

        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
