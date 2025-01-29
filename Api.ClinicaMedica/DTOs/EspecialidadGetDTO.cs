namespace Api.ClinicaMedica.DTOs
{
    public class EspecialidadGetDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<MedicoEspecialidadGetDTO> Medicos { get; set; } = new List<MedicoEspecialidadGetDTO>();
    }
}
