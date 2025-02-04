using Api.ClinicaMedica.DTOs.DtoLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTOs loginDtos) 
        {

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            
            }

           
            //chequear si el usuario existe
            //si el usuario existe le tenemos que devolver una respuesta positiva y 
            //un token que es una cadena que le sirve para usar los otros recursos
            //si el usuario no existe tenemos que devolver un bad request, como parametro le podemos poner como usuario inexistente

            var token = "sirve";

            return Ok(token);
        }
    }
}
