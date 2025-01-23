namespace Api.ClinicaMedica.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public List<Medico> medicos { get; set; } = new List<Medico>();
        public DateTime Dia { get; set; }
        public bool Activo { get; set; }
    }
}
