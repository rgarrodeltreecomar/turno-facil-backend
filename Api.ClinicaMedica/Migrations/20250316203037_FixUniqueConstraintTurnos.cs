using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueConstraintTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UQ_Turnos_Horario_Medico_Fecha",
                table: "Turnos",
                newName: "UQ_Turnos_Horario_Fecha_Medico");

            migrationBuilder.AlterColumn<string>(
                name: "IdEspecialidad",
                table: "Medicos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UQ_Turnos_Horario_Fecha_Medico",
                table: "Turnos",
                newName: "UQ_Turnos_Horario_Medico_Fecha");

            migrationBuilder.AlterColumn<string>(
                name: "IdEspecialidad",
                table: "Medicos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
