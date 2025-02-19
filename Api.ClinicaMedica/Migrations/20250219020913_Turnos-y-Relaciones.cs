using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class TurnosyRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHorario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMedico = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Asistencia = table.Column<bool>(type: "bit", nullable: false),
                    IdPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Disponible")
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdMedico",
                table: "Turnos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdPaciente",
                table: "Turnos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "UQ_Turnos_Horario_Medico_Fecha",
                table: "Turnos",
                columns: new[] { "IdHorario", "IdMedico", "Fecha" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
