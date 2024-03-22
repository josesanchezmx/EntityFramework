using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataRetoClase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("19269fe4-2d5c-4d7d-bcae-6ef190b53390"), null, "Actividades Personales", 20 },
                    { new Guid("bfe30f5b-116a-4781-bb5c-bf956e457201"), null, "Actividades Escolares", 60 }
                });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3d3c69c7-868c-418b-9bc0-49b4bfd68550"),
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 21, 19, 42, 22, 359, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("db64cd9a-f505-4d46-8a2c-68b225aaf50a"),
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 21, 19, 42, 22, 359, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Terminada", "Titulo" },
                values: new object[,]
                {
                    { new Guid("2d18f412-bda7-41de-b19d-99f6837a0811"), new Guid("19269fe4-2d5c-4d7d-bcae-6ef190b53390"), null, new DateTime(2024, 3, 21, 19, 42, 22, 359, DateTimeKind.Local).AddTicks(2847), 1, true, "Inscribirse al GYM" },
                    { new Guid("d4250210-9322-4183-b05c-d6199284c09c"), new Guid("bfe30f5b-116a-4781-bb5c-bf956e457201"), null, new DateTime(2024, 3, 21, 19, 42, 22, 359, DateTimeKind.Local).AddTicks(2842), 2, false, "Terminar la Web API con el Metodo GET y PUT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("2d18f412-bda7-41de-b19d-99f6837a0811"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("d4250210-9322-4183-b05c-d6199284c09c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("19269fe4-2d5c-4d7d-bcae-6ef190b53390"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("bfe30f5b-116a-4781-bb5c-bf956e457201"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3d3c69c7-868c-418b-9bc0-49b4bfd68550"),
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 21, 19, 22, 55, 72, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("db64cd9a-f505-4d46-8a2c-68b225aaf50a"),
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 21, 19, 22, 55, 72, DateTimeKind.Local).AddTicks(7992));
        }
    }
}
