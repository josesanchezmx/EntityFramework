using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("5d997b60-6592-47ae-a311-44826951c5f3"), null, "Actividades pendientes", 20 },
                    { new Guid("bba57e73-fdc4-4247-93d8-02e49731ea82"), null, "Actividades Personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Terminada", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3d3c69c7-868c-418b-9bc0-49b4bfd68550"), new Guid("5d997b60-6592-47ae-a311-44826951c5f3"), null, new DateTime(2024, 3, 21, 19, 22, 55, 72, DateTimeKind.Local).AddTicks(7970), 1, false, "Pago de servicios publicos" },
                    { new Guid("db64cd9a-f505-4d46-8a2c-68b225aaf50a"), new Guid("bba57e73-fdc4-4247-93d8-02e49731ea82"), null, new DateTime(2024, 3, 21, 19, 22, 55, 72, DateTimeKind.Local).AddTicks(7992), 0, false, "Terminar de hacer tu limpieza de Habitacion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3d3c69c7-868c-418b-9bc0-49b4bfd68550"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("db64cd9a-f505-4d46-8a2c-68b225aaf50a"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5d997b60-6592-47ae-a311-44826951c5f3"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("bba57e73-fdc4-4247-93d8-02e49731ea82"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
