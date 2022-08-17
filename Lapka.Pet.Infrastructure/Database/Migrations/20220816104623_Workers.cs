using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Workers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Workers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");
        }
    }
}
