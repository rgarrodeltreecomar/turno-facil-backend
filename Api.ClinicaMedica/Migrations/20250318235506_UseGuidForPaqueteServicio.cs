using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class UseGuidForPaqueteServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar la clave primaria existente
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaqueteServicios",
                table: "PaqueteServicios");

            // 2. Renombrar columna Id original a OldId
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaqueteServicios",
                newName: "OldId");

            // 3. Crear nueva columna Id como GUID
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PaqueteServicios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // 4. Eliminar columna OldId
            migrationBuilder.DropColumn(
                name: "OldId",
                table: "PaqueteServicios");

            // 5. Establecer nueva clave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_PaqueteServicios",
                table: "PaqueteServicios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar clave primaria
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaqueteServicios",
                table: "PaqueteServicios");

            // 2. Recrear columna original
            migrationBuilder.AddColumn<string>(
                name: "OldId",
                table: "PaqueteServicios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // 3. Restaurar datos (opcional, si es necesario)
            migrationBuilder.Sql(@"
                UPDATE PaqueteServicios
                SET OldId = CAST(Id AS nvarchar(450))
            ");

            // 4. Eliminar columna Guid
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PaqueteServicios");

            // 5. Renombrar a Id original
            migrationBuilder.RenameColumn(
                name: "OldId",
                table: "PaqueteServicios",
                newName: "Id");

            // 6. Restablecer clave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_PaqueteServicios",
                table: "PaqueteServicios",
                column: "Id");
        }
    }
}

