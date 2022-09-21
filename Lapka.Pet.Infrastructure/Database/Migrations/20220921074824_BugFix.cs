using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoLink",
                schema: "pets",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Pets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Archives",
                schema: "pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archives_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "pets",
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archives_ShelterId",
                schema: "pets",
                table: "Archives",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archives",
                schema: "pets");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                schema: "pets",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
