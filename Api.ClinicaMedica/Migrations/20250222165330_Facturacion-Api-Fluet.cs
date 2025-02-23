using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class FacturacionApiFluet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturaciones_Consultas_ConsultaIdConsulta",
                table: "Facturaciones");

            migrationBuilder.DropIndex(
                name: "IX_Facturaciones_ConsultaIdConsulta",
                table: "Facturaciones");

            migrationBuilder.DropColumn(
                name: "ConsultaIdConsulta",
                table: "Facturaciones");

            migrationBuilder.AlterColumn<string>(
                name: "IdConsulta",
                table: "Facturaciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_IdConsulta",
                table: "Facturaciones",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturaciones_Consultas_IdConsulta",
                table: "Facturaciones",
                column: "IdConsulta",
                principalTable: "Consultas",
                principalColumn: "IdConsulta",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturaciones_Consultas_IdConsulta",
                table: "Facturaciones");

            migrationBuilder.DropIndex(
                name: "IX_Facturaciones_IdConsulta",
                table: "Facturaciones");

            migrationBuilder.AlterColumn<string>(
                name: "IdConsulta",
                table: "Facturaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ConsultaIdConsulta",
                table: "Facturaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_ConsultaIdConsulta",
                table: "Facturaciones",
                column: "ConsultaIdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturaciones_Consultas_ConsultaIdConsulta",
                table: "Facturaciones",
                column: "ConsultaIdConsulta",
                principalTable: "Consultas",
                principalColumn: "IdConsulta");
        }
    }
}
