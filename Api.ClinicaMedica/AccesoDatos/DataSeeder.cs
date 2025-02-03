using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.AccesoDatos
{
    public class DataSeeder
    {
        public static void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any()) // Solo agrega si no existen roles
            {
                context.Roles.AddRange(
                    new Rol { Nombre = "Administrador" },
                    new Rol { Nombre = "Médico" },
                    new Rol { Nombre = "Paciente" }
                );
                context.SaveChanges(); // Guarda los cambios
            }
        }
    }
}