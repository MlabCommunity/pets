using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Dzialaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "pets",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "pets",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "pets",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "pets",
                table: "Advertisements");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");
        }
    }
}
