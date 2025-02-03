using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs.DtoLogin
{
    public class LoginDTOs 
    {
        [Required]
        public string Email { get; set; } = null!;
      
        [Required]
        public string Password { get; set; } 

    }
}
