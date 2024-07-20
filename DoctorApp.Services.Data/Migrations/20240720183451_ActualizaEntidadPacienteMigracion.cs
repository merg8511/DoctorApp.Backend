using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorApp.Services.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizaEntidadPacienteMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualizadoPorId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreadoPorId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ActualizadoPorId",
                table: "Pacientes",
                column: "ActualizadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CreadoPorId",
                table: "Pacientes",
                column: "CreadoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_AspNetUsers_ActualizadoPorId",
                table: "Pacientes",
                column: "ActualizadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_AspNetUsers_CreadoPorId",
                table: "Pacientes",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_AspNetUsers_ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_AspNetUsers_CreadoPorId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_CreadoPorId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Pacientes");
        }
    }
}
