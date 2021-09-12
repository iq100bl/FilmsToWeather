using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class UpdateSizeUrlLocalYandex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropColumn(
                name: "FilmsId",
                table: "UserFilms");

            migrationBuilder.RenameColumn(
                name: "FilmDataId",
                table: "FilmModels",
                newName: "UserFilmsDataId");

            migrationBuilder.AlterColumn<string>(
                name: "UrlLocalYandex",
                table: "WeatherCityInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmModels_UserFilmsDataId",
                table: "FilmModels",
                column: "UserFilmsDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmModels_UserFilms_UserFilmsDataId",
                table: "FilmModels",
                column: "UserFilmsDataId",
                principalTable: "UserFilms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_UserFilms_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.DropIndex(
                name: "IX_FilmModels_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.RenameColumn(
                name: "UserFilmsDataId",
                table: "FilmModels",
                newName: "FilmDataId");

            migrationBuilder.AlterColumn<string>(
                name: "UrlLocalYandex",
                table: "WeatherCityInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FilmsId",
                table: "UserFilms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    FilmDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => new { x.FilmDataId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_Views_FilmModels_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "FilmModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Views_UserFilms_FilmDataId",
                        column: x => x.FilmDataId,
                        principalTable: "UserFilms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Views_FilmsId",
                table: "Views",
                column: "FilmsId");
        }
    }
}
