using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bettingsoccerscoresapi.Migrations
{
    public partial class updateSoccerGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SoccerGames",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SoccerGames");
        }
    }
}
