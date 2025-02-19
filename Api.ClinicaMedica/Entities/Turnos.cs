namespace Api.ClinicaMedica.Entities
{
    public class Turnos
    {
        public string IdTurno { get; set; }

        public string IdHorario { get; set; }

        public string IdMedico { get; set; }

        public DateTime Fecha { get; set; }

        public bool Asistencia { get; set; }

        public string? IdPaciente { get; set; }

        public string Estado { get; set; } = null!;

        public virtual Horarios Horario { get; set; } = null!;

        public virtual Medicos Medico { get; set; } = null!;

        public virtual Pacientes? Paciente { get; set; }
    }
}
