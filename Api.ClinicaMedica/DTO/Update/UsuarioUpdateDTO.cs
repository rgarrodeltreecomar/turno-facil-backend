﻿namespace Api.ClinicaMedica.DTO.Update
{
    public class UsuarioUpdateDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string Email { get; set; }  // Unique
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int IdRol { get; set; }
    }
}
