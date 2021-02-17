using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class AddStatusIdToRaceResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeMillis",
                table: "RaceResults");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "RaceResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Time",
                table: "RaceResults",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_StatusId",
                table: "RaceResults",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_RaceStatuses_StatusId",
                table: "RaceResults",
                column: "StatusId",
                principalTable: "RaceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_RaceStatuses_StatusId",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_StatusId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "RaceResults");

            migrationBuilder.AddColumn<long>(
                name: "TimeMillis",
                table: "RaceResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
