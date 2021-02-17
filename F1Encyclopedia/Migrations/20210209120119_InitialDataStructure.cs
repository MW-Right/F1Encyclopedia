using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class InitialDataStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverInformations",
                columns: table => new
                {
                    DriverInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(maxLength: 2, nullable: false),
                    DaddysCash = table.Column<bool>(nullable: false),
                    Pace = table.Column<int>(maxLength: 2, nullable: false),
                    Experience = table.Column<int>(maxLength: 2, nullable: false),
                    Racecraft = table.Column<int>(maxLength: 2, nullable: false),
                    Awareness = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverInformations", x => x.DriverInformationId);
                });

            migrationBuilder.CreateTable(
                name: "Constructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TitleSponsor = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Constructors_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false),
                    DriverInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_DriverInformations_DriverInformationId",
                        column: x => x.DriverInformationId,
                        principalTable: "DriverInformations",
                        principalColumn: "DriverInformationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hex = table.Column<string>(nullable: true),
                    ConstructorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colours_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceWeekends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false),
                    Year = table.Column<int>(maxLength: 2, nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceWeekends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceWeekends_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    RaceWeekendId = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverRatings_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverRatings_RaceWeekends_RaceWeekendId",
                        column: x => x.RaceWeekendId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    FromId = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRoles_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRoles_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRoles_RaceWeekends_FromId",
                        column: x => x.FromId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonRoles_RaceWeekends_ToId",
                        column: x => x.ToId,
                        principalTable: "RaceWeekends",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colours_ConstructorId",
                table: "Colours",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Constructors_CountryId",
                table: "Constructors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_PersonId",
                table: "DriverRatings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_RaceWeekendId",
                table: "DriverRatings",
                column: "RaceWeekendId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_ConstructorId",
                table: "PersonRoles",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_EmployeeId",
                table: "PersonRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_FromId",
                table: "PersonRoles",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_ToId",
                table: "PersonRoles",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NationalityId",
                table: "Persons",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceWeekends_TrackId",
                table: "RaceWeekends",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_CountryId",
                table: "Tracks",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "DriverRatings");

            migrationBuilder.DropTable(
                name: "PersonRoles");

            migrationBuilder.DropTable(
                name: "Constructors");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RaceWeekends");

            migrationBuilder.DropTable(
                name: "DriverInformations");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
