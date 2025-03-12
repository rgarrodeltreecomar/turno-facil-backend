namespace Api.ClinicaMedica.Entities
{
    public class Pacientes
    {
        public string IdPaciente { get; set; }
        public Guid IdUsuario { get; set; }
        public bool ObraSocial { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Relaciones
        public Usuarios Usuario { get; set; }
        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
