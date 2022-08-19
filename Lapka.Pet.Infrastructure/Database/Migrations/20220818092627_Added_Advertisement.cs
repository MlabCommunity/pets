using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Added_Advertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropIndex(
                name: "IX_ShelterPets_ShelterId",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.CreateTable(
                name: "Advertisements",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvertisementBaseId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Advertisements_AdvertisementBaseId",
                        column: x => x.AdvertisementBaseId,
                        principalSchema: "pets",
                        principalTable: "Advertisements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShelterAdvertisements",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsReserved = table.Column<bool>(type: "boolean", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterAdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisements_Advertisements_Id",
                        column: x => x.Id,
                        principalSchema: "pets",
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisements_ShelterPets_PetIdId",
                        column: x => x.PetIdId,
                        principalSchema: "pets",
                        principalTable: "ShelterPets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdvertisementBaseId",
                schema: "pets",
                table: "Photos",
                column: "AdvertisementBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_PetIdId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "PetIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "ShelterAdvertisements",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Advertisements",
                schema: "pets");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "pets",
                table: "Shelters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterPets",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelterPets_ShelterId",
                schema: "pets",
                table: "ShelterPets",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");
        }
    }
}
