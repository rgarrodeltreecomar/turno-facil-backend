using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class StartMysql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    IdEspecialidad = table.Column<string>(type: "varchar(255)", nullable: false),
                    Detalle = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.IdEspecialidad);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<string>(type: "varchar(255)", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HorarioFin = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Dni = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdEspecialidad = table.Column<string>(type: "varchar(255)", nullable: true),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false),
                    ObraSocial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServiciosMedicos",
                columns: table => new
                {
                    IdServicio = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdMedico = table.Column<string>(type: "varchar(255)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosMedicos", x => new { x.IdServicio, x.IdMedico });
                    table.ForeignKey(
                        name: "FK_ServiciosMedicos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosMedicos_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdConsulta = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraConsulta = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    IdPaciente = table.Column<string>(type: "varchar(255)", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObraSocial = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdHorario = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdMedico = table.Column<string>(type: "varchar(255)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Asistencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdPaciente = table.Column<string>(type: "varchar(255)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Disponible")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IdTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facturaciones",
                columns: table => new
                {
                    IdFactura = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdConsulta = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "timestamp", nullable: false),
                    MetodoPago = table.Column<string>(type: "longtext", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturaciones", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturaciones_Consultas_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consultas",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    IdConsulta = table.Column<string>(type: "varchar(50)", nullable: false),
                    CodigoPaquete = table.Column<Guid>(type: "char(36)", nullable: false),
                    PrecioPaquete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdMedico = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IdServicio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => new { x.IdConsulta, x.CodigoPaquete });
                    table.ForeignKey(
                        name: "FK_Paquetes_Consultas_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consultas",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "IdHorario", "HorarioFin", "HorarioInicio" },
                values: new object[,]
                {
                    { "H1", new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { "H10", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { "H11", new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { "H12", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { "H13", new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { "H14", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { "H15", new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { "H16", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { "H2", new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { "H3", new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { "H4", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { "H5", new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { "H6", new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { "H7", new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { "H8", new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { "H9", new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 13, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Médico" },
                    { 3, "Paciente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_IdConsulta",
                table: "Facturaciones",
                column: "IdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdEspecialidad",
                table: "Medicos",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdUsuario",
                table: "Medicos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuario",
                table: "Pacientes",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosMedicos_IdMedico",
                table: "ServiciosMedicos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdMedico",
                table: "Turnos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdPaciente",
                table: "Turnos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "UQ_Turnos_Horario_Fecha_Medico",
                table: "Turnos",
                columns: new[] { "IdHorario", "IdMedico", "Fecha" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturaciones");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "ServiciosMedicos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
