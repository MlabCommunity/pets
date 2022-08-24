using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactorrrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_ShelterAdvertisements_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "pets",
                table: "Shelters",
                newName: "Localization");

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId1",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_ShelterAdvertisements_ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropColumn(
                name: "ShelterId1",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.RenameColumn(
                name: "Localization",
                schema: "pets",
                table: "Shelters",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
