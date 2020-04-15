using Microsoft.EntityFrameworkCore.Migrations;

namespace CinephilesChoiceAPI.Migrations
{
    public partial class AddedNomineePropertyToNominationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nominee",
                table: "Nominations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nominee",
                table: "Nominations");
        }
    }
}
