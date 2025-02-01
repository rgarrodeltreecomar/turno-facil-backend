﻿// <auto-generated />
using System;
using Api.ClinicaMedica.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.ClinicaMedica.Models.CitaMedica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Abonado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraConsulta")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PaqueteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PaqueteId");

                    b.ToTable("CitasMedicas", (string)null);
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Especialidades", (string)null);
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaHoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("Horarios", (string)null);
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.PaqueteServicio", b =>
                {
                    b.Property<int>("PaqueteId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("PaqueteId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("PaquetesServicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Dni")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly?>("FechaNac")
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator().HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.HasBaseType("Api.ClinicaMedica.Models.Usuario");

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Sueldo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("Usuarios", t =>
                        {
                            t.Property("Activo")
                                .HasColumnName("Medico_Activo");
                        });

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paciente", b =>
                {
                    b.HasBaseType("Api.ClinicaMedica.Models.Usuario");

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("ObraSocial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.CitaMedica", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Medico", "Medico")
                        .WithMany("CitaMedica")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Paciente", "Paciente")
                        .WithMany("CitaMedica")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Paquete", "Paquete")
                        .WithMany("CitaMedica")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Horario", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Medico", "Medico")
                        .WithMany("Turnos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.PaqueteServicio", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Paquete", "Paquete")
                        .WithMany("Servicios")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.ClinicaMedica.Models.Servicio", "Servicio")
                        .WithMany("Paquetes")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paquete");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.HasOne("Api.ClinicaMedica.Models.Especialidad", "Especialidad")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Especialidad", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paquete", b =>
                {
                    b.Navigation("CitaMedica");

                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Servicio", b =>
                {
                    b.Navigation("Paquetes");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Medico", b =>
                {
                    b.Navigation("CitaMedica");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Api.ClinicaMedica.Models.Paciente", b =>
                {
                    b.Navigation("CitaMedica");
                });
#pragma warning restore 612, 618
        }
    }
}
