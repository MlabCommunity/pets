using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pets");

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsSterilized = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    cat_bread = table.Column<int>(type: "integer", nullable: true),
                    cat_color = table.Column<int>(type: "integer", nullable: true),
                    dog_bread = table.Column<int>(type: "integer", nullable: true),
                    dog_color = table.Column<int>(type: "integer", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Krs = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelterPets",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterPets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterPets_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelterPets_ShelterId",
                schema: "pets",
                table: "ShelterPets",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "ShelterPets",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Shelters",
                schema: "pets");
        }
    }
}
