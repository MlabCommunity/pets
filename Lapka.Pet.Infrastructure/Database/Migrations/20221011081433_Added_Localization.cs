using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Added_Localization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "pets",
                table: "ShelterPets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "pets",
                table: "ShelterPets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                schema: "pets",
                table: "ShelterPets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "pets",
                table: "LostPet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "pets",
                table: "LostPet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                schema: "pets",
                table: "LostPet",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "pets",
                table: "LostPet");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "pets",
                table: "LostPet");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                schema: "pets",
                table: "LostPet");
        }
    }
}
