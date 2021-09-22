using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class renamePropertyFilmModelFilmIdToFilmIdApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels");

            migrationBuilder.DropTable(
                name: "FilmsRatings");

            migrationBuilder.DropIndex(
                name: "IX_FilmModels_FilmsRatingId",
                table: "FilmModels");

            migrationBuilder.DropColumn(
                name: "FilmsRatingId",
                table: "FilmModels");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmModels",
                newName: "FilmIdApi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilmIdApi",
                table: "FilmModels",
                newName: "FilmId");

            migrationBuilder.AddColumn<Guid>(
                name: "FilmsRatingId",
                table: "FilmModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmsRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmModels_FilmsRatingId",
                table: "FilmModels",
                column: "FilmsRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsRatings_UserId",
                table: "FilmsRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels",
                column: "FilmsRatingId",
                principalTable: "FilmsRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
