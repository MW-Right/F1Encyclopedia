using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class ReworkRaceResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_LapTimes_FastestLapId",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_FastestLapId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "FastestLapId",
                table: "RaceResults");

            migrationBuilder.AlterColumn<long>(
                name: "Time",
                table: "RaceResults",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "RaceResultId",
                table: "LapTimes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "Time",
                table: "RaceResults",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FastestLapId",
                table: "RaceResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_FastestLapId",
                table: "RaceResults",
                column: "FastestLapId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_LapTimes_FastestLapId",
                table: "RaceResults",
                column: "FastestLapId",
                principalTable: "LapTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
