using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactorrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localization",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                schema: "pets",
                table: "ShelterAdvertisements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                schema: "pets",
                table: "ShelterAdvertisements");
        }
    }
}
