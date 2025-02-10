using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class SeAñadioLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar las claves foráneas anteriores con la tabla 'Usuarios'
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

            // Eliminar la clave primaria de 'Usuarios'
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            // Renombrar la tabla 'Usuarios' a 'Usuario'
            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            // Renombrar los índices asociados
            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuario",
                newName: "IX_Usuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EspecialidadId",
                table: "Usuario",
                newName: "IX_Usuario_EspecialidadId");

            // Volver a agregar la clave primaria a 'Usuario'
            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            // Restaurar las claves foráneas con la tabla 'Usuario'
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar las claves foráneas relacionadas
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

            // Eliminar la clave primaria de 'Usuario'
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            // Renombrar la tabla 'Usuario' de nuevo a 'Usuarios'
            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            // Renombrar los índices asociados
            migrationBuilder.RenameIndex(
                name: "IX_Usuario_RolId",
                table: "Usuarios",
                newName: "IX_Usuarios_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EspecialidadId",
                table: "Usuarios",
                newName: "IX_Usuarios_EspecialidadId");

            // Volver a agregar la clave primaria a 'Usuarios'
            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            // Restaurar las claves foráneas con la tabla 'Usuarios'
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
    }
}
