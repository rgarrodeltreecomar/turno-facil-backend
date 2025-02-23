using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class modificacionconsultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoIdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_MedicoIdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteIdPaciente",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "MedicoIdMedico",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PacienteIdPaciente",
                table: "Consultas");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontoTotal",
                table: "Consultas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "IdPaciente",
                table: "Consultas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdMedico",
                table: "Consultas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontoTotal",
                table: "Consultas",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "IdPaciente",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdMedico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicoIdMedico",
                table: "Consultas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacienteIdPaciente",
                table: "Consultas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoIdMedico",
                table: "Consultas",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteIdPaciente",
                table: "Consultas",
                column: "PacienteIdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoIdMedico",
                table: "Consultas",
                column: "MedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                table: "Consultas",
                column: "PacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
