using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.ClinicaMedica.Utilities
{
    public static class FuncionesToken
    {
        // Generar el token con datos de la cuenta y datos del appsetting.json, el key, etc
        public static string GenerarToken(RegisteredViewModel usuario, string rol, IConfiguration confi)
        {
            // Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(confi["Jwt:Key"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            // Claims
            var _claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email ?? ""),
                new Claim("rol", rol),
                new Claim("nombre", usuario.Nombre ?? ""),
                new Claim("apellido", usuario.Apellido ?? ""),
                new Claim("dni", usuario.Dni ?? ""),
                new Claim("fechaNacimiento", usuario.FechaNacimiento?.ToString("yyyy-MM-dd") ?? ""),
                new Claim("telefono", usuario.Telefono ?? ""),
                new Claim("direccion", usuario.Direccion ?? ""),
                new Claim("idRol", usuario.IdRol.ToString())
            };

            // Payload
            var _payload = new JwtPayload(
                issuer: confi["Jwt:Issuer"],
                audience: confi["Jwt:Audience"],
                claims: _claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(60)
            );

            // Generar el token
            var _token = new JwtSecurityToken(_header, _payload);

            return new JwtSecurityTokenHandler().WriteToken(_token);
        }

    }
}
