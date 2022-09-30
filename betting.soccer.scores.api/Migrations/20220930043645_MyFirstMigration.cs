using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bettingsoccerscoresapi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoccerTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerTeams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoccerTeams_Id",
                table: "SoccerTeams",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoccerTeams");
        }
    }
}
