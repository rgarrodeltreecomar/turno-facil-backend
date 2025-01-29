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
    [Migration("20250128205635_AddRegisterUser")]
    partial class AddRegisterUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.ClinicaMedica.Models.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<decimal>("Sueldo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("especialidadId")
                        .HasColumnType("int");

                    b.Property<int>("medicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("especialidadId");

                    b.HasIndex("medicoId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("ObraSocial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("pacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoServicio")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Abonado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateOnly>("FechaConsulta")
                        .HasColumnType("date");

                    b.Property<DateTime>("HoraConsulta")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("medicoId")
                        .HasColumnType("int");

                    b.Property<int>("pacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("medicoId");

                    b.HasIndex("pacienteId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("FechaNac")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HorarioMedico", b =>
                {
                    b.Property<int>("horariosId")
                        .HasColumnType("int");

                    b.Property<int>("medicosId")
                        .HasColumnType("int");

                    b.HasKey("horariosId", "medicosId");

                    b.HasIndex("medicosId");

                    b.ToTable("HorarioMedico");
                });

            modelBuilder.Entity("PaqueteServicio", b =>
                {
                    b.Property<int>("paquetesId")
                        .HasColumnType("int");

                    b.Property<int>("serviciosId")
                        .HasColumnType("int");

                    b.HasKey("paquetesId", "serviciosId");

                    b.HasIndex("serviciosId");

                    b.ToTable("PaqueteServicio");
                });

            modelBuilder.Entity("ServicioTurno", b =>
                {
                    b.Property<int>("serviciosId")
                        .HasColumnType("int");

                    b.Property<int>("serviciosId1")
                        .HasColumnType("int");

                    b.HasKey("serviciosId", "serviciosId1");

                    b.HasIndex("serviciosId1");

                    b.ToTable("ServicioTurno");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Especialidad", "especialidad")
                        .WithMany("medicos")
                        .HasForeignKey("especialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Usuario", "medico")
                        .WithMany()
                        .HasForeignKey("medicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("especialidad");

                    b.Navigation("medico");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paciente", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Usuario", "paciente")
                        .WithMany()
                        .HasForeignKey("pacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("paciente");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Turno", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Medico", "medico")
                        .WithMany("turnos")
                        .HasForeignKey("medicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("pacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medico");

                    b.Navigation("paciente");
                });

            modelBuilder.Entity("HorarioMedico", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Horario", null)
                        .WithMany()
                        .HasForeignKey("horariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Medico", null)
                        .WithMany()
                        .HasForeignKey("medicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteServicio", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Paquete", null)
                        .WithMany()
                        .HasForeignKey("paquetesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Servicio", null)
                        .WithMany()
                        .HasForeignKey("serviciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServicioTurno", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Turno", null)
                        .WithMany()
                        .HasForeignKey("serviciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Servicio", null)
                        .WithMany()
                        .HasForeignKey("serviciosId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Especialidad", b =>
                {
                    b.Navigation("medicos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.Navigation("turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
