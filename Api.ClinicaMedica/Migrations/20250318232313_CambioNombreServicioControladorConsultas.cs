using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreServicioControladorConsultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsultaIdConsulta",
                table: "Turnos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdConsulta",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdPaciente",
                table: "PaqueteServicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConsultaIdConsulta",
                table: "DetalleServicios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ObraSocial",
                table: "Consultas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ConsultaIdConsulta",
                table: "Turnos",
                column: "ConsultaIdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicios_ConsultaIdConsulta",
                table: "DetalleServicios",
                column: "ConsultaIdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleServicios_Consultas_ConsultaIdConsulta",
                table: "DetalleServicios",
                column: "ConsultaIdConsulta",
                principalTable: "Consultas",
                principalColumn: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Consultas_ConsultaIdConsulta",
                table: "Turnos",
                column: "ConsultaIdConsulta",
                principalTable: "Consultas",
                principalColumn: "IdConsulta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleServicios_Consultas_ConsultaIdConsulta",
                table: "DetalleServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Consultas_ConsultaIdConsulta",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ConsultaIdConsulta",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_DetalleServicios_ConsultaIdConsulta",
                table: "DetalleServicios");

            migrationBuilder.DropColumn(
                name: "ConsultaIdConsulta",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "PaqueteServicios");

            migrationBuilder.DropColumn(
                name: "ConsultaIdConsulta",
                table: "DetalleServicios");

            migrationBuilder.DropColumn(
                name: "ObraSocial",
                table: "Consultas");
        }
    }
}
