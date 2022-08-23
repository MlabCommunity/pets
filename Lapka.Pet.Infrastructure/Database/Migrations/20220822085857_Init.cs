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
                name: "Advertisements",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

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
                name: "Photos",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelterPets",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterPets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteerings",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteerings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LostPetAdvertisements",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfDisappearance = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StreetOfDisappearance = table.Column<string>(type: "text", nullable: false),
                    CityOfDisappearance = table.Column<string>(type: "text", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostPetAdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LostPetAdvertisements_Advertisements_Id",
                        column: x => x.Id,
                        principalSchema: "pets",
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    VolunteeringId = table.Column<Guid>(type: "uuid", nullable: false),
                    Krs = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelters_Volunteerings_VolunteeringId",
                        column: x => x.VolunteeringId,
                        principalSchema: "pets",
                        principalTable: "Volunteerings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterAdvertisements",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsReserved = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_ShelterAdvertisements_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteers_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisements_ShelterId",
                schema: "pets",
                table: "ShelterAdvertisements",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_ShelterId",
                schema: "pets",
                table: "Volunteers",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ShelterId",
                schema: "pets",
                table: "Workers",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LostPetAdvertisements",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Pets",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "ShelterAdvertisements",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "ShelterPets",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Volunteers",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Workers",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Advertisements",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Shelters",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Volunteerings",
                schema: "pets");
        }
    }
}
