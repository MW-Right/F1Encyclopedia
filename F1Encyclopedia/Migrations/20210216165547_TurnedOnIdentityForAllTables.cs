using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class TurnedOnIdentityForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_DriverInformations_DriverInformationId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverInformations",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "DriverInformationId",
                table: "DriverInformations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RaceWeekends",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RaceWeekends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceWiki",
                table: "RaceWeekends",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DriverInformations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "DriverInformations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverInformations",
                table: "DriverInformations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DriverInformations_DriverId",
                table: "DriverInformations",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Persons_DriverId",
                table: "DriverInformations",
                column: "DriverId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_DriverInformations_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Persons_DriverId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_DriverInformations_DriverInformationId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverInformations",
                table: "DriverInformations");

            migrationBuilder.DropIndex(
                name: "IX_DriverInformations_DriverId",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RaceWeekends");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RaceWeekends");

            migrationBuilder.DropColumn(
                name: "RaceWiki",
                table: "RaceWeekends");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "DriverInformations");

            migrationBuilder.AddColumn<int>(
                name: "DriverInformationId",
                table: "DriverInformations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverInformations",
                table: "DriverInformations",
                column: "DriverInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_DriverInformations_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "DriverInformationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
