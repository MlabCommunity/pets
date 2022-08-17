using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Added_Volunteering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VolunteeringId",
                schema: "pets",
                table: "Shelters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Volunteering",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteering", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_VolunteeringId",
                schema: "pets",
                table: "Shelters",
                column: "VolunteeringId");

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

            migrationBuilder.DropTable(
                name: "Volunteering",
                schema: "pets");

            migrationBuilder.DropIndex(
                name: "IX_Shelters_VolunteeringId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "VolunteeringId",
                schema: "pets",
                table: "Shelters");
        }
    }
}
