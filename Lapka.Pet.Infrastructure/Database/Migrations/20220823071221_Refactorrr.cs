using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactorrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PetId",
                schema: "pets",
                table: "Photos",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PetId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PetId",
                schema: "pets",
                table: "Photos");
        }
    }
}
