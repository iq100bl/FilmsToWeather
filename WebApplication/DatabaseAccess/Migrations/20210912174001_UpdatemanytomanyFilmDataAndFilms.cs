using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class UpdatemanytomanyFilmDataAndFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_UserFilms_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.DropIndex(
                name: "IX_FilmModels_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.DropColumn(
                name: "UserFilmsDataId",
                table: "FilmModels");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.AddColumn<Guid>(
                name: "UserFilmsDataId",
                table: "FilmModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
