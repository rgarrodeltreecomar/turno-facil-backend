using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class ActualicacionHorarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H1");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H10");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H11");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H12");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H13");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H14");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H15");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H16");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H2");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H3");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H4");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H5");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H6");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H7");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H8");

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "IdHorario",
                keyValue: "H9");

            migrationBuilder.AddColumn<string>(
                name: "IdMedico",
                table: "Horarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_IdMedico",
                table: "Horarios",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Medicos_IdMedico",
                table: "Horarios",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Medicos_IdMedico",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_IdMedico",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Horarios");

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
        }
    }
}
