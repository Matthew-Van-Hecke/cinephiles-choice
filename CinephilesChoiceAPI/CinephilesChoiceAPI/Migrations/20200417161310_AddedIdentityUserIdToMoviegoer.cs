using Microsoft.EntityFrameworkCore.Migrations;

namespace CinephilesChoiceAPI.Migrations
{
    public partial class AddedIdentityUserIdToMoviegoer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Moviegoers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Moviegoers");
        }
    }
}
