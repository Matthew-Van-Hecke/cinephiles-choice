using Microsoft.EntityFrameworkCore.Migrations;

namespace CinephilesChoiceAPI.Migrations
{
    public partial class MadeMovieIdOnNominationModelNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_Movies_MovieId",
                table: "Nominations");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Nominations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_Movies_MovieId",
                table: "Nominations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_Movies_MovieId",
                table: "Nominations");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Nominations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_Movies_MovieId",
                table: "Nominations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
