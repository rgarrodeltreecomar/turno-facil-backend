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

        //DbSet

        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Medico> Medicos => Set<Medico>();
        public DbSet<Especialidad> Especialidades => Set<Especialidad>();
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<Paquete> Paquetes => Set<Paquete>();
        public DbSet<CitaMedica> CitasMedicas => Set<CitaMedica>();
        public DbSet<PaqueteServicio> PaquetesServicios => Set<PaqueteServicio>();
        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //Relaciones: 

            //Paciente(N) - CitaMedica(1);
            modelBuilder.Entity<Paciente>().
                HasMany(p => p.CitaMedica).
                WithOne(cm => cm.Paciente).
                HasForeignKey(cm => cm.PacienteId).
                OnDelete(DeleteBehavior.NoAction);

            //CitaMedica(1) - Medico(N)
            modelBuilder.Entity<Medico>().
                HasMany(m => m.CitaMedica).
                WithOne(cm => cm.Medico).
                HasForeignKey(cm => cm.MedicoId);

            //Medico(N) - Especialidad(1)
            modelBuilder.Entity<Medico>().
                HasOne(m => m.Especialidad).
                WithMany(e => e.Medicos).
                HasForeignKey(m => m.EspecialidadId);

            //Horario(1) - Medico(N)
            modelBuilder.Entity<Horario>().
                HasOne(h => h.Medico).
                WithMany(m => m.Turnos).
                HasForeignKey(h => h.MedicoId).
                OnDelete(DeleteBehavior.NoAction);

            //Paquete-CitaMedica
            modelBuilder.Entity<CitaMedica>()
                .HasOne(cm => cm.Paquete)
                .WithMany(p => p.CitaMedica)
                .HasForeignKey(cm => cm.PaqueteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la tabla intermedia PaqueteServicio
            modelBuilder.Entity<PaqueteServicio>()
                .HasKey(ps => new { ps.PaqueteId, ps.ServicioId }); // Clave compuesta

            // Relación: Paquete -> PaqueteServicio (1:N)
            modelBuilder.Entity<PaqueteServicio>()
                .HasOne(ps => ps.Paquete)
                .WithMany(p => p.Servicios) // Propiedad de navegación: Paquete.Servicios
                .HasForeignKey(ps => ps.PaqueteId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento al eliminar

            // Relación: Servicio -> PaqueteServicio (1:N)
            modelBuilder.Entity<PaqueteServicio>()
                .HasOne(ps => ps.Servicio)
                .WithMany(s => s.Paquetes) // Propiedad de navegación: Servicio.Paquetes
                .HasForeignKey(ps => ps.ServicioId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento al eliminar

            // Usuario(1) - Rol(N)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
