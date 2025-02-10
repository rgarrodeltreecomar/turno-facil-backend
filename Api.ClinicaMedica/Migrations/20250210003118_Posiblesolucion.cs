using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class Posiblesolucion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Usuario_MedicoId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Usuario_PacienteId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Usuario_MedicoId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Especialidades_EspecialidadId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_RolId",
                table: "Usuarios",
                newName: "IX_Usuarios_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EspecialidadId",
                table: "Usuarios",
                newName: "IX_Usuarios_EspecialidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Usuarios_MedicoId",
                table: "CitasMedicas",
                column: "MedicoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Usuarios_PacienteId",
                table: "CitasMedicas",
                column: "PacienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Usuarios_MedicoId",
                table: "Horarios",
                column: "MedicoId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Especialidades_EspecialidadId",
                table: "Usuarios",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Usuarios_MedicoId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Usuarios_PacienteId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Usuarios_MedicoId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Especialidades_EspecialidadId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuario",
                newName: "IX_Usuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EspecialidadId",
                table: "Usuario",
                newName: "IX_Usuario_EspecialidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Usuario_MedicoId",
                table: "CitasMedicas",
                column: "MedicoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Usuario_PacienteId",
                table: "CitasMedicas",
                column: "PacienteId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Usuario_MedicoId",
                table: "Horarios",
                column: "MedicoId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Especialidades_EspecialidadId",
                table: "Usuario",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
