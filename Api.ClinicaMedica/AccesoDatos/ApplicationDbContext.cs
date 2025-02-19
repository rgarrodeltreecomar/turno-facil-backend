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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Medicos>()
                .HasKey(m => m.IdMedico);

            modelBuilder.Entity<Medicos>()
                .HasOne(m => m.Especialidad)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.IdEspecialidad);

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.Property(e => e.Sueldo)
                      .HasColumnType("decimal(18,2)"); // Especifica la precisión y escala
            });

            modelBuilder.Entity<Pacientes>()
                .HasKey(p => p.IdPaciente);

            modelBuilder.Entity<Especialidades>()
                .HasKey(e => e.IdEspecialidad); // Define la clave primaria explícitamente

            modelBuilder.Entity<Especialidades>()
                .HasMany(e => e.Medicos)
                .WithOne(m => m.Especialidad)
                .HasForeignKey(m => m.IdEspecialidad)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada
        }


    }
}
