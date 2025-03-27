using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class RediseñoConsultasPaquetes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdMedico",
                table: "Paquetes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdServicio",
                table: "Paquetes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "IdServicio",
                table: "Paquetes");
        }
    }
}
