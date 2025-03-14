using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Update
{
    public class MedicosUpdateDTO
    {
        public string IdMedico { get; set; }

        public string? IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        // Relaciones Propiedad de Navegacion
        public UsuarioUpdateDTO Usuario { get; set; }
    }
}
