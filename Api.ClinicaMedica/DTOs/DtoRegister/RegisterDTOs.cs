using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs.DtoRegister
{
    public class RegisterDTOs
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El RolId es obligatorio.")]
        public Guid RolId { get; set; }

    }
}
