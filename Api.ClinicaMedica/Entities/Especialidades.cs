namespace Api.ClinicaMedica.Entities
{
    public class Especialidades
    {
        public string IdEspecialidad { get; set; }
        public string Detalle { get; set; }

        // Relación 1 a muchos con Medico
        public ICollection<Medicos> Medicos { get; set; } = new List<Medicos>();
    }
}
