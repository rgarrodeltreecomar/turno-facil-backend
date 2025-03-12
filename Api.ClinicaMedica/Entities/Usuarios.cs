namespace Api.ClinicaMedica.Entities
{
    public class Usuarios
    {
        public Guid IdUsuario { get; set; } = Guid.NewGuid(); // Se genera un GUID por defecto
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public string Email { get; set; }  // Unique
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string PasswordHash { get; set; } = null!;
        public int IdRol { get; set; }

        // Propiedad de navegacion
        public Roles Rol { get; set; }

        // Relación con Médico o Paciente
        public Medicos Medico { get; set; }
        public Pacientes Paciente { get; set; }
    }
}
