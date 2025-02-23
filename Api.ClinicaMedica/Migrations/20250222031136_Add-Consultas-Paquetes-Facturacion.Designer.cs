﻿// <auto-generated />
using System;
using Api.ClinicaMedica.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250222031136_Add-Consultas-Paquetes-Facturacion")]
    partial class AddConsultasPaquetesFacturacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.Property<string>("IdCitas")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("MontoTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PagadoONo")
                        .HasColumnType("int");

                    b.HasKey("IdCitas");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdServicio");

                    b.ToTable("CitasMedicas");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Consultas", b =>
                {
                    b.Property<string>("IdConsulta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraConsulta")
                        .HasColumnType("time");

                    b.Property<string>("IdMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPaquete")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdServicio")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MedicoIdMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("PacienteIdPaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdPaquete");

                    b.HasIndex("IdServicio");

                    b.HasIndex("MedicoIdMedico");

                    b.HasIndex("PacienteIdPaciente");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.DetalleServicios", b =>
                {
                    b.Property<string>("IdCitas")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdServicio")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("MontoParcial")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCitas", "IdServicio");

                    b.HasIndex("IdServicio");

                    b.ToTable("DetalleServicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Especialidades", b =>
                {
                    b.Property<string>("IdEspecialidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Facturacion", b =>
                {
                    b.Property<string>("IdFactura")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConsultaIdConsulta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("IdConsulta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontoPagado")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdFactura");

                    b.HasIndex("ConsultaIdConsulta");

                    b.ToTable("Facturaciones");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Horarios", b =>
                {
                    b.Property<string>("IdHorario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("HorarioFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.HasKey("IdHorario");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Medicos", b =>
                {
                    b.Property<string>("IdMedico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdEspecialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Sueldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedico");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Pacientes", b =>
                {
                    b.Property<string>("IdPaciente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ObraSocial")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaciente");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.PaqueteServicio", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoPaquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoPaquete");

                    b.HasIndex("CodigoServicio");

                    b.ToTable("PaqueteServicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Paquetes", b =>
                {
                    b.Property<string>("CodigoPaquete")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioPaquete")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("CodigoPaquete");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            IdRol = 2,
                            Nombre = "Médico"
                        },
                        new
                        {
                            IdRol = 3,
                            Nombre = "Paciente"
                        });
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Servicios", b =>
                {
                    b.Property<string>("IdServicio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicios", (string)null);
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Turnos", b =>
                {
                    b.Property<string>("IdTurno")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Asistencia")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Disponible");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("IdHorario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPaciente")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdTurno");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdHorario", "IdMedico", "Fecha")
                        .IsUnique()
                        .HasDatabaseName("UQ_Turnos_Horario_Medico_Fecha");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Usuarios", b =>
                {
                    b.Property<string>("IdUsuario")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Dni")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Medicos", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Pacientes", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Servicios", "Servicio")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Consultas", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Paquetes", "Paquete")
                        .WithMany()
                        .HasForeignKey("IdPaquete")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Api.ClinicaMedica.Entities.Servicios", "Servicio")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Api.ClinicaMedica.Entities.Medicos", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoIdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Pacientes", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteIdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Paquete");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.DetalleServicios", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.CitasMedicas", "CitaMedica")
                        .WithMany("DetallesServicios")
                        .HasForeignKey("IdCitas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Servicios", "Servicio")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CitaMedica");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Facturacion", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Consultas", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaIdConsulta");

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Medicos", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Especialidades", "Especialidad")
                        .WithMany("Medicos")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.PaqueteServicio", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Paquetes", "Paquete")
                        .WithMany("PaqueteServicios")
                        .HasForeignKey("CodigoPaquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Servicios", "Servicio")
                        .WithMany()
                        .HasForeignKey("CodigoServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paquete");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Turnos", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Horarios", "Horario")
                        .WithMany("Turnos")
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Medicos", "Medico")
                        .WithMany("Turnos")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Entities.Pacientes", "Paciente")
                        .WithMany("Turnos")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Horario");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Usuarios", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Entities.Roles", null)
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.Navigation("DetallesServicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Especialidades", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Horarios", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Medicos", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Pacientes", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Entities.Paquetes", b =>
                {
                    b.Navigation("PaqueteServicios");
                });
#pragma warning restore 612, 618
        }
    }
}
