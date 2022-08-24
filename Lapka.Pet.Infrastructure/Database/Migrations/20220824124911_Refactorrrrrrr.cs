using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactorrrrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropColumn(
                name: "CityOfDisappearance",
                schema: "pets",
                table: "LostPetAdvertisements");

            migrationBuilder.DropColumn(
                name: "StreetOfDisappearance",
                schema: "pets",
                table: "LostPetAdvertisements");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                schema: "pets",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                schema: "pets",
                table: "Advertisements");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityOfDisappearance",
                schema: "pets",
                table: "LostPetAdvertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetOfDisappearance",
                schema: "pets",
                table: "LostPetAdvertisements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
