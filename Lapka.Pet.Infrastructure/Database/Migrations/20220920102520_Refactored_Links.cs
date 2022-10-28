using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactored_Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoId",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoId",
                schema: "pets",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Shelters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                schema: "pets",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "PhotoLink",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                schema: "pets",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoId",
                schema: "pets",
                table: "Shelters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoId",
                schema: "pets",
                table: "Pets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
