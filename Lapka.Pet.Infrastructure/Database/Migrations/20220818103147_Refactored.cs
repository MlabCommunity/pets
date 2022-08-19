using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterAdvertisements_ShelterPets_PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_ShelterAdvertisements_PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements");

            migrationBuilder.RenameColumn(
                name: "PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements",
                newName: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetId",
                schema: "pets",
                table: "ShelterAdvertisements",
                newName: "PetIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "PetIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterAdvertisements_ShelterPets_PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "PetIdId",
                principalSchema: "pets",
                principalTable: "ShelterPets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
