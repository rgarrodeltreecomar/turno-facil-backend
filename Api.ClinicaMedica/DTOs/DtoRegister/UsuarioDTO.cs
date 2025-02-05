namespace Api.ClinicaMedica.DTOs.DtoRegister
{
    public class UsuarioDTO
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RolId { get; set; }
    }
}
