using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class RemovedRaceResultFromLapTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LapTimes_RaceResults_RaceResultId",
                table: "LapTimes");

            migrationBuilder.DropIndex(
                name: "IX_LapTimes_RaceResultId",
                table: "LapTimes");

            migrationBuilder.DropColumn(
                name: "RaceResultId",
                table: "LapTimes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceResultId",
                table: "LapTimes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LapTimes_RaceResultId",
                table: "LapTimes",
                column: "RaceResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_LapTimes_RaceResults_RaceResultId",
                table: "LapTimes",
                column: "RaceResultId",
                principalTable: "RaceResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
