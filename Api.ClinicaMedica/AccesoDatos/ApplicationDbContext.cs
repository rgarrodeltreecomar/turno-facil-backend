using Api.ClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.ClinicaMedica.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Paciente> Pacientes =>Set<Paciente>();
        public DbSet<Medico> Medicos => Set<Medico>();
        public DbSet<Especialidad> Especialidad => Set<Especialidad>();
        public DbSet<Servicio> Servicios { get; set; } = default!;
        public DbSet<Turno> Turnos => Set<Turno>();
        public DbSet<Paquete> Paquetes => Set<Paquete>();
        public DbSet<Horario> Horarios => Set<Horario>();
    }
}
