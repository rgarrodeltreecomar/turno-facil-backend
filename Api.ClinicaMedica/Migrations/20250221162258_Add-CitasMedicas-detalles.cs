using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class AddCitasMedicasdetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitasMedicas",
                columns: table => new
                {
                    IdCitas = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMedico = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPaciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdServicio = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PagadoONo = table.Column<int>(type: "int", nullable: false),
                    ServiciosIdServicio = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasMedicas", x => x.IdCitas);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Servicios_ServiciosIdServicio",
                        column: x => x.ServiciosIdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio");
                });

            migrationBuilder.CreateTable(
                name: "DetalleServicios",
                columns: table => new
                {
                    IdCitas = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdServicio = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MontoParcial = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleServicios", x => new { x.IdCitas, x.IdServicio });
                    table.ForeignKey(
                        name: "FK_DetalleServicios_CitasMedicas_IdCitas",
                        column: x => x.IdCitas,
                        principalTable: "CitasMedicas",
                        principalColumn: "IdCitas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleServicios_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_IdMedico",
                table: "CitasMedicas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_IdPaciente",
                table: "CitasMedicas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_IdServicio",
                table: "CitasMedicas",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_ServiciosIdServicio",
                table: "CitasMedicas",
                column: "ServiciosIdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicios_IdServicio",
                table: "DetalleServicios",
                column: "IdServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleServicios");

            migrationBuilder.DropTable(
                name: "CitasMedicas");
        }
    }
}
