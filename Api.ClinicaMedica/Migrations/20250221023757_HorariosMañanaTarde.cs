using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class HorariosMañanaTarde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

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
        }
    }
}
