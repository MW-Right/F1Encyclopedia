using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class RenamePersonToDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverRatings_Persons_PersonId",
                table: "DriverRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_LapTimes_Persons_DriverId",
                table: "LapTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_LapTimes_RaceWeekends_RaceWeekendId",
                table: "LapTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Persons_EmployeeId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifyings_Persons_DriverId",
                table: "Qualifyings");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Persons_DriverId",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Persons_DriverId",
                table: "DriverInformations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "DriverInformations");

            migrationBuilder.DropIndex(
                name: "IX_DriverRatings_PersonId",
                table: "DriverRatings");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "DriverRatings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    WikiUrl = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(maxLength: 2, nullable: true),
                    DaddysCash = table.Column<bool>(nullable: false),
                    Pace = table.Column<int>(maxLength: 2, nullable: true),
                    Experience = table.Column<int>(maxLength: 2, nullable: true),
                    Racecraft = table.Column<int>(maxLength: 2, nullable: true),
                    Awareness = table.Column<int>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_DriverId",
                table: "DriverRatings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CountryId",
                table: "Drivers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRatings_Drivers_DriverId",
                table: "DriverRatings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LapTimes_Drivers_DriverId",
                table: "LapTimes",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LapTimes_RaceWeekends_RaceWeekendId",
                table: "LapTimes",
                column: "RaceWeekendId",
                principalTable: "RaceWeekends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Drivers_EmployeeId",
                table: "PersonRoles",
                column: "EmployeeId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifyings_Drivers_DriverId",
                table: "Qualifyings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Drivers_DriverId",
                table: "RaceResults",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverRatings_Drivers_DriverId",
                table: "DriverRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_LapTimes_Drivers_DriverId",
                table: "LapTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_LapTimes_RaceWeekends_RaceWeekendId",
                table: "LapTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Drivers_EmployeeId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifyings_Drivers_DriverId",
                table: "Qualifyings");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Drivers_DriverId",
                table: "RaceResults");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_DriverRatings_DriverId",
                table: "DriverRatings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "DriverRatings");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverInformationId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WikiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DriverInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Awareness = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DaddysCash = table.Column<bool>(type: "bit", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    Experience = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Pace = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Racecraft = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverInformations_Persons_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_PersonId",
                table: "DriverRatings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverInformations_DriverId",
                table: "DriverInformations",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryId",
                table: "Persons",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                unique: true,
                filter: "[DriverInformationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRatings_Persons_PersonId",
                table: "DriverRatings",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LapTimes_Persons_DriverId",
                table: "LapTimes",
                column: "DriverId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LapTimes_RaceWeekends_RaceWeekendId",
                table: "LapTimes",
                column: "RaceWeekendId",
                principalTable: "RaceWeekends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Persons_EmployeeId",
                table: "PersonRoles",
                column: "EmployeeId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifyings_Persons_DriverId",
                table: "Qualifyings",
                column: "DriverId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Persons_DriverId",
                table: "RaceResults",
                column: "DriverId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_DriverInformations_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
