using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                schema: "pets",
                table: "Volunteering",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DailyHelpDescription",
                schema: "pets",
                table: "Volunteering",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DonationDescription",
                schema: "pets",
                table: "Volunteering",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDailyHelpActive",
                schema: "pets",
                table: "Volunteering",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDonationActive",
                schema: "pets",
                table: "Volunteering",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTakingDogsOutActive",
                schema: "pets",
                table: "Volunteering",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TakingDogsOutDescription",
                schema: "pets",
                table: "Volunteering",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Volunteering_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteering",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "DailyHelpDescription",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "DonationDescription",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "IsDailyHelpActive",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "IsDonationActive",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "IsTakingDogsOutActive",
                schema: "pets",
                table: "Volunteering");

            migrationBuilder.DropColumn(
                name: "TakingDogsOutDescription",
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
    }
}
