namespace Api.ClinicaMedica.Entities
{
    public class Horarios
    {
        public string IdHorario { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFin { get; set; }

        public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
