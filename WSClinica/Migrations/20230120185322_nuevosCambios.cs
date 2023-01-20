using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSClinica.Migrations
{
    public partial class nuevosCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Clinicas_ClinicaID",
                table: "Habitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habitaciones",
                table: "Habitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicas",
                table: "Clinicas");

            migrationBuilder.RenameTable(
                name: "Habitaciones",
                newName: "Habitacion");

            migrationBuilder.RenameTable(
                name: "Clinicas",
                newName: "Clinica");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_ClinicaID",
                table: "Habitacion",
                newName: "IX_Habitacion_ClinicaID");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Habitacion",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinica",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioActividades",
                table: "Clinica",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clinica",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habitacion",
                table: "Habitacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinica",
                table: "Clinica",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_Clinica_ClinicaID",
                table: "Habitacion",
                column: "ClinicaID",
                principalTable: "Clinica",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_Clinica_ClinicaID",
                table: "Habitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habitacion",
                table: "Habitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinica",
                table: "Clinica");

            migrationBuilder.RenameTable(
                name: "Habitacion",
                newName: "Habitaciones");

            migrationBuilder.RenameTable(
                name: "Clinica",
                newName: "Clinicas");

            migrationBuilder.RenameIndex(
                name: "IX_Habitacion_ClinicaID",
                table: "Habitaciones",
                newName: "IX_Habitaciones_ClinicaID");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Habitaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioActividades",
                table: "Clinicas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habitaciones",
                table: "Habitaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicas",
                table: "Clinicas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Clinicas_ClinicaID",
                table: "Habitaciones",
                column: "ClinicaID",
                principalTable: "Clinicas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
