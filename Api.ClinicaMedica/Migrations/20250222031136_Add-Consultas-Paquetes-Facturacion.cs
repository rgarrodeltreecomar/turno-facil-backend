using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultasPaquetesFacturacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Servicios_ServiciosIdServicio",
                table: "CitasMedicas");

            migrationBuilder.DropIndex(
                name: "IX_CitasMedicas_ServiciosIdServicio",
                table: "CitasMedicas");

            migrationBuilder.DropColumn(
                name: "ServiciosIdServicio",
                table: "CitasMedicas");

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    CodigoPaquete = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioPaquete = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.CodigoPaquete);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdConsulta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraConsulta = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdServicio = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IdPaquete = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    PacienteIdPaciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicoIdMedico = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Paquetes_IdPaquete",
                        column: x => x.IdPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "CodigoPaquete",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Consultas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteServicios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoPaquete = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoServicio = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteServicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaqueteServicios_Paquetes_CodigoPaquete",
                        column: x => x.CodigoPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "CodigoPaquete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteServicios_Servicios_CodigoServicio",
                        column: x => x.CodigoServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturaciones",
                columns: table => new
                {
                    IdFactura = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ConsultaIdConsulta = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturaciones", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturaciones_Consultas_ConsultaIdConsulta",
                        column: x => x.ConsultaIdConsulta,
                        principalTable: "Consultas",
                        principalColumn: "IdConsulta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdPaquete",
                table: "Consultas",
                column: "IdPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdServicio",
                table: "Consultas",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoIdMedico",
                table: "Consultas",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteIdPaciente",
                table: "Consultas",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_ConsultaIdConsulta",
                table: "Facturaciones",
                column: "ConsultaIdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicios_CodigoPaquete",
                table: "PaqueteServicios",
                column: "CodigoPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicios_CodigoServicio",
                table: "PaqueteServicios",
                column: "CodigoServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturaciones");

            migrationBuilder.DropTable(
                name: "PaqueteServicios");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.AddColumn<string>(
                name: "ServiciosIdServicio",
                table: "CitasMedicas",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_ServiciosIdServicio",
                table: "CitasMedicas",
                column: "ServiciosIdServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Servicios_ServiciosIdServicio",
                table: "CitasMedicas",
                column: "ServiciosIdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio");
        }
    }
}
