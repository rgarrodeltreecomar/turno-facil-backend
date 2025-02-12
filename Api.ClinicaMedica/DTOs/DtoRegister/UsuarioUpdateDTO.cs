namespace Api.ClinicaMedica.DTOs.DtoRegister
{
    public class UsuarioUpdateDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Rol { get; set; }
    }
}
