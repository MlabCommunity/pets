using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Renameee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Visits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PetId",
                schema: "pets",
                table: "Visits",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PetId",
                schema: "pets",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PetId",
                schema: "pets",
                table: "Visits");
        }
    }
}
