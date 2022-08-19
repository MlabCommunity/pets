using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refacored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Advertisements_AdvertisementBaseId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AdvertisementBaseId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AdvertisementBaseId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "pets",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "pets",
                table: "Advertisements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdvertisementBaseId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "pets",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "pets",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdvertisementBaseId",
                schema: "pets",
                table: "Photos",
                column: "AdvertisementBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Advertisements_AdvertisementBaseId",
                schema: "pets",
                table: "Photos",
                column: "AdvertisementBaseId",
                principalSchema: "pets",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }
    }
}
