using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class AddLapToLapTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeMillis",
                table: "LapTimes");

            migrationBuilder.AddColumn<int>(
                name: "Lap",
                table: "LapTimes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Time",
                table: "LapTimes",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lap",
                table: "LapTimes");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "LapTimes");

            migrationBuilder.AddColumn<long>(
                name: "TimeMillis",
                table: "LapTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
