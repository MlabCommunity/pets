using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Bugfix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_Shelters_ShelterId",
                schema: "pets",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Pets_PetId",
                schema: "pets",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Volunteering_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                schema: "pets",
                table: "VisitTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Shelters_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "pets",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Volunteers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Volunteering",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitId",
                schema: "pets",
                table: "VisitTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Visits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterPets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Likes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Archives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LostOthers",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LostOthers_LostPet_Id",
                        column: x => x.Id,
                        principalSchema: "pets",
                        principalTable: "LostPet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_Pets_Id",
                        column: x => x.Id,
                        principalSchema: "pets",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterOthers",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterOthers_ShelterPets_Id",
                        column: x => x.Id,
                        principalSchema: "pets",
                        principalTable: "ShelterPets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteering_ShelterId",
                schema: "pets",
                table: "Volunteering",
                column: "ShelterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_Shelters_ShelterId",
                schema: "pets",
                table: "Archives",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Pets_PetId",
                schema: "pets",
                table: "Likes",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                schema: "pets",
                table: "VisitTypes",
                column: "VisitId",
                principalSchema: "pets",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteering_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteering",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_Shelters_ShelterId",
                schema: "pets",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Pets_PetId",
                schema: "pets",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                schema: "pets",
                table: "VisitTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteering_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "LostOthers",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "Others",
                schema: "pets");

            migrationBuilder.DropTable(
                name: "ShelterOthers",
                schema: "pets");

            migrationBuilder.DropIndex(
                name: "IX_Volunteering_ShelterId",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Workers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "pets",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Volunteers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitId",
                schema: "pets",
                table: "VisitTypes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Visits",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "VolunteeringId",
                schema: "pets",
                table: "Shelters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "ShelterPets",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                schema: "pets",
                table: "Likes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                schema: "pets",
                table: "Archives",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_Shelters_ShelterId",
                schema: "pets",
                table: "Archives",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Pets_PetId",
                schema: "pets",
                table: "Likes",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Pets_PetId",
                schema: "pets",
                table: "Photos",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterPets_Shelters_ShelterId",
                schema: "pets",
                table: "ShelterPets",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Volunteering_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId",
                principalSchema: "pets",
                principalTable: "Volunteering",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Pets_PetId",
                schema: "pets",
                table: "Visits",
                column: "PetId",
                principalSchema: "pets",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                schema: "pets",
                table: "VisitTypes",
                column: "VisitId",
                principalSchema: "pets",
                principalTable: "Visits",
                principalColumn: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Shelters_ShelterId",
                schema: "pets",
                table: "Volunteers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Shelters_ShelterId",
                schema: "pets",
                table: "Workers",
                column: "ShelterId",
                principalSchema: "pets",
                principalTable: "Shelters",
                principalColumn: "Id");
        }
    }
}
