using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Pet.Infrastructure.Database.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdvertisementId",
                schema: "pets",
                table: "Photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdvertisementId",
                schema: "pets",
                table: "Photos",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Advertisements_AdvertisementId",
                schema: "pets",
                table: "Photos",
                column: "AdvertisementId",
                principalSchema: "pets",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Advertisements_AdvertisementId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AdvertisementId",
                schema: "pets",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                schema: "pets",
                table: "Photos");
        }
    }
}
