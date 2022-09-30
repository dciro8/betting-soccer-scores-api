using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bettingsoccerscoresapi.Migrations
{
    public partial class My1FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoccerGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamAId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    TeamBId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DateGame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScoreTeamA = table.Column<byte>(type: "tinyint", maxLength: 10, nullable: false),
                    ScoreTeamB = table.Column<byte>(type: "tinyint", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerGames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_Id",
                table: "SoccerGames",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoccerGames");
        }
    }
}
