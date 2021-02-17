using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class AddedResultsQualifyingAndLapTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LapTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceWeekendId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(maxLength: 2, nullable: false),
                    TimeMillis = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LapTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LapTimes_Persons_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LapTimes_RaceWeekends_RaceWeekendId",
                        column: x => x.RaceWeekendId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qualifyings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceWeekendId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(maxLength: 2, nullable: false),
                    Q1 = table.Column<DateTime>(nullable: true),
                    Q2 = table.Column<DateTime>(nullable: true),
                    Q3 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifyings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifyings_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qualifyings_Persons_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qualifyings_RaceWeekends_RaceWeekendId",
                        column: x => x.RaceWeekendId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceWeekendId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    GridPosition = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Laps = table.Column<int>(nullable: false),
                    TimeMillis = table.Column<long>(nullable: false),
                    FastestLapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceResults_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceResults_Persons_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceResults_LapTimes_FastestLapId",
                        column: x => x.FastestLapId,
                        principalTable: "LapTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceResults_RaceWeekends_RaceWeekendId",
                        column: x => x.RaceWeekendId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LapTimes_DriverId",
                table: "LapTimes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_LapTimes_RaceWeekendId",
                table: "LapTimes",
                column: "RaceWeekendId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifyings_ConstructorId",
                table: "Qualifyings",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifyings_DriverId",
                table: "Qualifyings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifyings_RaceWeekendId",
                table: "Qualifyings",
                column: "RaceWeekendId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_ConstructorId",
                table: "RaceResults",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_DriverId",
                table: "RaceResults",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_FastestLapId",
                table: "RaceResults",
                column: "FastestLapId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceWeekendId",
                table: "RaceResults",
                column: "RaceWeekendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualifyings");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "RaceStatuses");

            migrationBuilder.DropTable(
                name: "LapTimes");
        }
    }
}
