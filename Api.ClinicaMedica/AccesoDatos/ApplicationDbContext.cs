using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.ClinicaMedica.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------ Personas -------------
            modelBuilder.Entity<Personas>()
                .HasKey(p => p.IdPersona);

            modelBuilder.Entity<Personas>()
                .HasOne(p => p.Paciente)
            .WithOne(p => p.Persona)
                .HasForeignKey<Pacientes>(p => p.IdPersona);

            modelBuilder.Entity<Personas>()
                .HasOne(p => p.Medico)
            .WithOne(m => m.Persona)
                .HasForeignKey<Medicos>(m => m.IdPersona);

            modelBuilder.Entity<Personas>()
                .HasOne(p => p.Rol)
                .WithMany(r => r.Personas)
                .HasForeignKey(p => p.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Personas>()
            .HasOne(p => p.Rol)  // Una Persona tiene un Rol
            .WithMany(r => r.Personas)  // Un Rol puede estar en muchas Personas
            .HasForeignKey(p => p.IdRol)  // Clave foránea en Personas
            .OnDelete(DeleteBehavior.Restrict);  // Evita la eliminación en cascada
            // ---------- Medicos ----------------

            modelBuilder.Entity<Medicos>()
                .HasKey(m => m.IdMedico);

            modelBuilder.Entity<Medicos>()
                .HasOne(m => m.Persona)
                .WithOne(p => p.Medico)
                .HasForeignKey<Medicos>(m => m.IdPersona);

            modelBuilder.Entity<Medicos>()
                .HasOne(m => m.Especialidad)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.IdEspecialidad)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada

            modelBuilder.Entity<Medicos>()
                .HasMany(m => m.Turnos)
                .WithOne(t => t.Medico)
                .HasForeignKey(t => t.IdMedico)
                .OnDelete(DeleteBehavior.SetNull); // Si se borra un médico, los turnos quedan huérfanos

            modelBuilder.Entity<Medicos>()
                    .HasMany(m => m.Turnos)
                    .WithOne(t => t.Medico) // Asegúrate de que `Turnos` tenga una propiedad `Medico`
                    .HasForeignKey(t => t.IdMedico)
                    .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.Property(e => e.Sueldo)
                      .HasColumnType("decimal(18,2)"); // Especifica la precisión y escala
            });

            // -------- Pacientes ----------------

            modelBuilder.Entity<Pacientes>()
                .HasKey(p => p.IdPaciente);

            modelBuilder.Entity<Pacientes>()
                .HasOne(p => p.Persona)
                .WithOne(p => p.Paciente)
                .HasForeignKey<Pacientes>(p => p.IdPersona);

            modelBuilder.Entity<Pacientes>()
                .HasMany(p => p.Turnos)
                .WithOne(t => t.Paciente)
                .HasForeignKey(t => t.IdPaciente)
                .OnDelete(DeleteBehavior.SetNull); // Si se borra un paciente, los turnos quedan sin paciente

            // -------- Especialidades ------------

            modelBuilder.Entity<Especialidades>()
                .HasKey(e => e.IdEspecialidad); // Define la clave primaria explícitamente

            modelBuilder.Entity<Especialidades>()
                .HasMany(e => e.Medicos)
                .WithOne(m => m.Especialidad)
                .HasForeignKey(m => m.IdEspecialidad)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada

            // Agregado para el segundo commit, Config para Personas, Horarios Turnos
            // 📌 Horarios
            modelBuilder.Entity<Horarios>()
                .HasKey(h => h.IdHorario);

            modelBuilder.Entity<Horarios>()
                .HasMany(h => h.Turnos)
                .WithOne(t => t.Horario)
                .HasForeignKey(t => t.IdHorario)
                .OnDelete(DeleteBehavior.Restrict); // Si se borra un horario, se eliminan los turnos

            // ----- 📌 Turnos ---------------

            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.HasKey(t => t.IdTurno);

                entity.Property(t => t.Fecha)
                .HasColumnType("date")
                .IsRequired();

                entity.Property(t => t.Estado)
                      .HasMaxLength(20)
                      .HasDefaultValue("Disponible");

                // Configurar IdPaciente como clave foránea nullable
                entity.HasOne(t => t.Paciente)
                    .WithMany(p => p.Turnos)    //Usa la colection de Turnos en Paciente
                    .HasForeignKey(t => t.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);

                entity.HasOne(t => t.Horario)
                    .WithMany(h => h.Turnos)
                    .HasForeignKey(t => t.IdHorario)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relacion con Medicos
                entity.HasOne(t => t.Medico)
                    .WithMany(h => h.Turnos)
                    .HasForeignKey(t => t.IdMedico)
                    .OnDelete(DeleteBehavior.Restrict);

                // Agregar restricción UNIQUE en HorarioId, MedicoId y Fecha
                entity.HasIndex(t => new { t.IdHorario, t.IdMedico, t.Fecha })
                    .IsUnique()
                    .HasDatabaseName("UQ_Turnos_Horario_Medico_Fecha");
            });

            // Configuración de la entidad Roles
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");

                entity.Property(r => r.IdRol)
                    .ValueGeneratedNever(); // Evita que se genere automáticamente (útil si insertas datos iniciales)

                entity.Property(r => r.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                // Relación con Personas (Uno a Muchos)
                entity.HasMany(r => r.Personas)
                    .WithOne(p => p.Rol)
                    .HasForeignKey(p => p.IdRol)
                    .OnDelete(DeleteBehavior.Restrict); // Evita eliminaciones en cascada

                // Seed de datos iniciales (opcional)
                entity.HasData(
                    new Roles { IdRol = 1, Nombre = "Administrador" },
                    new Roles { IdRol = 2, Nombre = "Médico" },
                    new Roles { IdRol = 3, Nombre = "Paciente" }
                );
            });

        }
    }
}
