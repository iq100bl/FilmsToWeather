using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class CorrectedTheLinkOfFilmsFromTheUserDateTransferredTheRatingToTheUseDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_UserFilms_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.DropIndex(
                name: "IX_FilmModels_UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.DropColumn(
                name: "UserFilmsDataId",
                table: "FilmModels");

            migrationBuilder.AddColumn<Guid>(
                name: "FilmId",
                table: "UserFilms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "Rating",
                table: "UserFilms",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmsRatingId",
                table: "FilmModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilms_FilmId",
                table: "UserFilms",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels",
                column: "FilmsRatingId",
                principalTable: "FilmsRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilms_FilmModels_FilmId",
                table: "UserFilms",
                column: "FilmId",
                principalTable: "FilmModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFilms_FilmModels_FilmId",
                table: "UserFilms");

            migrationBuilder.DropIndex(
                name: "IX_UserFilms_FilmId",
                table: "UserFilms");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "UserFilms");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UserFilms");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmsRatingId",
                table: "FilmModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                name: "FK_FilmModels_FilmsRatings_FilmsRatingId",
                table: "FilmModels",
                column: "FilmsRatingId",
                principalTable: "FilmsRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
