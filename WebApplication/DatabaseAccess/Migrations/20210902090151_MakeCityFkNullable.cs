using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class MakeCityFkNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_WeatherCityInfos_WeatherCitiesInfoId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_WeatherCitiesInfoId",
                table: "Cities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeatherCitiesInfoId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_WeatherCitiesInfoId",
                table: "Cities",
                column: "WeatherCitiesInfoId",
                unique: true,
                filter: "[WeatherCitiesInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_WeatherCityInfos_WeatherCitiesInfoId",
                table: "Cities",
                column: "WeatherCitiesInfoId",
                principalTable: "WeatherCityInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_WeatherCityInfos_WeatherCitiesInfoId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_WeatherCitiesInfoId",
                table: "Cities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeatherCitiesInfoId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_WeatherCitiesInfoId",
                table: "Cities",
                column: "WeatherCitiesInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_WeatherCityInfos_WeatherCitiesInfoId",
                table: "Cities",
                column: "WeatherCitiesInfoId",
                principalTable: "WeatherCityInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
