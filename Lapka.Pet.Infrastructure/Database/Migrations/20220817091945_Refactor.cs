using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Volunteering_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteering",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.RenameTable(
                name: "Volunteering",
                schema: "pets",
                newName: "Volunteerings",
                newSchema: "pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteerings",
                schema: "pets",
                table: "Volunteerings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Volunteerings_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId",
                principalSchema: "pets",
                principalTable: "Volunteerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Volunteerings_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteerings",
                schema: "pets",
                table: "Volunteerings");

            migrationBuilder.RenameTable(
                name: "Volunteerings",
                schema: "pets",
                newName: "Volunteering",
                newSchema: "pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteering",
                schema: "pets",
                table: "Volunteering",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Volunteering_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId",
                principalSchema: "pets",
                principalTable: "Volunteering",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
