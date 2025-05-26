using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class ImplementaciónTablaPaquetesServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
          name: "PaqueteServicio",
          columns: table => new
          {
              Id = table.Column<Guid>(type: "char(36)", nullable: false),
              PaqueteIdConsulta = table.Column<string>(type: "varchar(50)", nullable: false),
              PaqueteCodigoPaquete = table.Column<Guid>(type: "char(36)", nullable: false),
              ServicioIdServicio = table.Column<string>(type: "varchar(50)", nullable: false)
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_PaqueteServicio", x => x.Id);
              table.ForeignKey(
                  name: "FK_PaqueteServicio_Paquetes",
                  columns: x => new { x.PaqueteIdConsulta, x.PaqueteCodigoPaquete },
                  principalTable: "Paquetes",
                  principalColumns: new[] { "IdConsulta", "CodigoPaquete" },
                  onDelete: ReferentialAction.Cascade);
              table.ForeignKey(
                  name: "FK_PaqueteServicio_Servicios",
                  column: x => x.ServicioIdServicio,
                  principalTable: "Servicios",
                  principalColumn: "IdServicio",
                  onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_PaqueteIdConsulta_PaqueteCodigoPaquete",
                table: "PaqueteServicio",
                columns: new[] { "PaqueteIdConsulta", "PaqueteCodigoPaquete" });

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_ServicioIdServicio",
                table: "PaqueteServicio",
                column: "ServicioIdServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaqueteServicio");
        }
    }
}
