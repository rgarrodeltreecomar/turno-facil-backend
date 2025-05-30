﻿using Api.ClinicaMedica.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.ClinicaMedica.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Paquetes> Paquetes { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Facturacion> Facturaciones { get; set; }
        public DbSet<ServiciosMedicos> ServiciosMedicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ---------- Medicos ----------------

            modelBuilder.Entity<Medicos>()
                .ToTable("Medicos")
                .HasKey(m => m.IdMedico);

            modelBuilder.Entity<Medicos>()
                .Property(m => m.IdMedico)
                .ValueGeneratedNever(); // No se genera automáticamente porque es el mismo que `Usuarios.IdUsuario`

            modelBuilder.Entity<Medicos>()
                .HasOne(m => m.Usuario)
                .WithOne(u => u.Medico)
                .HasForeignKey<Medicos>(m => m.IdUsuario) // Clave foránea correcta
                .OnDelete(DeleteBehavior.Cascade);

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
                .ToTable("Pacientes")
                .HasKey(p => p.IdPaciente);

            modelBuilder.Entity<Pacientes>()
                .Property(p => p.IdPaciente)
                .ValueGeneratedNever(); // Se usa el mismo GUID de `Usuarios.IdUsuario`

            modelBuilder.Entity<Pacientes>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Paciente)
                .HasForeignKey<Pacientes>(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);


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

            // Sembrar franjas horarias de 30 minutos
            modelBuilder.Entity<Horarios>().HasData(
                // Turnos de la mañana: 08:00 - 12:00
                new Horarios { IdHorario = "H1", HorarioInicio = new TimeSpan(8, 0, 0), HorarioFin = new TimeSpan(8, 30, 0) },
                new Horarios { IdHorario = "H2", HorarioInicio = new TimeSpan(8, 30, 0), HorarioFin = new TimeSpan(9, 0, 0) },
                new Horarios { IdHorario = "H3", HorarioInicio = new TimeSpan(9, 0, 0), HorarioFin = new TimeSpan(9, 30, 0) },
                new Horarios { IdHorario = "H4", HorarioInicio = new TimeSpan(9, 30, 0), HorarioFin = new TimeSpan(10, 0, 0) },
                new Horarios { IdHorario = "H5", HorarioInicio = new TimeSpan(10, 0, 0), HorarioFin = new TimeSpan(10, 30, 0) },
                new Horarios { IdHorario = "H6", HorarioInicio = new TimeSpan(10, 30, 0), HorarioFin = new TimeSpan(11, 0, 0) },
                new Horarios { IdHorario = "H7", HorarioInicio = new TimeSpan(11, 0, 0), HorarioFin = new TimeSpan(11, 30, 0) },
                new Horarios { IdHorario = "H8", HorarioInicio = new TimeSpan(11, 30, 0), HorarioFin = new TimeSpan(12, 0, 0) },

                // Turnos de la tarde: 13:00 - 17:00
                new Horarios { IdHorario = "H9", HorarioInicio = new TimeSpan(13, 0, 0), HorarioFin = new TimeSpan(13, 30, 0) },
                new Horarios { IdHorario = "H10", HorarioInicio = new TimeSpan(13, 30, 0), HorarioFin = new TimeSpan(14, 0, 0) },
                new Horarios { IdHorario = "H11", HorarioInicio = new TimeSpan(14, 0, 0), HorarioFin = new TimeSpan(14, 30, 0) },
                new Horarios { IdHorario = "H12", HorarioInicio = new TimeSpan(14, 30, 0), HorarioFin = new TimeSpan(15, 0, 0) },
                new Horarios { IdHorario = "H13", HorarioInicio = new TimeSpan(15, 0, 0), HorarioFin = new TimeSpan(15, 30, 0) },
                new Horarios { IdHorario = "H14", HorarioInicio = new TimeSpan(15, 30, 0), HorarioFin = new TimeSpan(16, 0, 0) },
                new Horarios { IdHorario = "H15", HorarioInicio = new TimeSpan(16, 0, 0), HorarioFin = new TimeSpan(16, 30, 0) },
                new Horarios { IdHorario = "H16", HorarioInicio = new TimeSpan(16, 30, 0), HorarioFin = new TimeSpan(17, 0, 0) }
            );

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
                    .HasDatabaseName("UQ_Turnos_Horario_Fecha_Medico");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                // Tabla Usuario
                entity.ToTable("Usuarios")
                    .HasKey(u => u.IdUsuario);

                entity.Property(u => u.IdUsuario)
                    .ValueGeneratedNever(); // o .ValueGeneratedOnAdd(), pero sin DEFAULT

                entity.HasIndex(u => u.Email)
                    .IsUnique();

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                // Relación Usuario -> Rol (Muchos a Uno)
                entity.HasOne(u => u.Rol)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(u => u.IdRol)
                    .OnDelete(DeleteBehavior.Restrict);


                entity.Property(u => u.Telefono)
                    .HasMaxLength(20);

                entity.Property(u => u.Direccion)
                    .HasMaxLength(200);

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255); // Tamaño recomendado para almacenar hash


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

                // Seed de datos iniciales (opcional)
                entity.HasData(
                    new Roles { IdRol = 1, Nombre = "Administrador" },
                    new Roles { IdRol = 2, Nombre = "Médico" },
                    new Roles { IdRol = 3, Nombre = "Paciente" }
                );
            });

            // Servicios
            modelBuilder.Entity<Servicio>(entity =>
            {
                // Nombre de la tabla
                entity.ToTable("Servicios");

                // Clave primaria
                entity.HasKey(s => s.IdServicio);

                // Configuración de propiedades
                entity.Property(s => s.IdServicio)
                    .HasMaxLength(50)  // Longitud máxima del ID
                    .IsRequired();     // No puede ser nulo

                entity.Property(s => s.Nombre)
                    .HasMaxLength(100) // Longitud máxima del nombre
                    .IsRequired();     // No puede ser nulo

                entity.Property(s => s.Descripcion)
                    .HasMaxLength(500); // Longitud máxima de la descripción

                entity.Property(s => s.Precio)
                    .HasColumnType("decimal(18,2)") // Define la precisión del decimal
                    .IsRequired(); // No puede ser nulo

            });

            modelBuilder.Entity<ServiciosMedicos>(entity =>
            {
                entity.ToTable("ServiciosMedicos");

                // Clave primaria (string, GUID generado en C#)
                entity.HasKey(sm => sm.Id);

                entity.Property(sm => sm.Id)
                      .HasColumnType("varchar(36)")
                      .IsRequired();

                entity.Property(sm => sm.Precio)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.HasOne(sm => sm.Medico)
                      .WithMany(m => m.ServiciosMedicos)
                      .HasForeignKey(sm => sm.IdMedico)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sm => sm.Servicio)
                      .WithMany(s => s.ServiciosMedicos)
                      .HasForeignKey(sm => sm.IdServicio)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(sm => sm.IdMedico)
                      .HasColumnType("varchar(36)")
                      .IsRequired();

                entity.Property(sm => sm.IdServicio)
                      .HasColumnType("varchar(36)")
                      .IsRequired();
            });


            // ------ Consultas ------------------ 

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.HasKey(c => c.IdConsulta);

                entity.Property(c => c.IdConsulta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.FechaConsulta)
                      .IsRequired();

                entity.Property(c => c.HoraConsulta)
                      .IsRequired();

                entity.Property(c => c.MontoTotal)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(c => c.Pagado)
                      .IsRequired();

                // Clave foránea opcional (nullable) para Paciente
                entity.HasOne(c => c.Paciente)
                      .WithMany() // Si Paciente tiene una lista de Consultas, usa `.WithMany(p => p.Consultas)`
                      .HasForeignKey(c => c.IdPaciente)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.NoAction); // Opcional: si se borra el paciente, se pone en NULL

                entity.HasMany(c => c.Paquetes)
                    .WithOne()
                    .HasForeignKey(p => p.IdConsulta)
                    .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<Facturacion>()
                .Property(f => f.FechaPago)
                .HasColumnType("timestamp");

            modelBuilder.Entity<Facturacion>()
            .Property(f => f.MontoPagado)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Paquetes>()
                .HasKey(p => new { p.IdConsulta, p.CodigoPaquete });

            modelBuilder.Entity<Paquetes>()
            .Property(p => p.PrecioPaquete)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Paquetes>()
                .Property(p => p.IdMedico)
                    .HasMaxLength(50);

            modelBuilder.Entity<Paquetes>()
                .Property(p => p.IdServicio)
                    .HasMaxLength(50);

            modelBuilder.Entity<Facturacion>()
                .HasOne(f => f.Consulta)  // Relación 1 a 1 o 1 a muchos
                .WithMany()  // Si `Consultas` no tiene lista de `Facturacion`, usa WithMany()
                .HasForeignKey(f => f.IdConsulta)  // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);  // Evita eliminaciones en cascada si no lo deseas

        }
    }
}
