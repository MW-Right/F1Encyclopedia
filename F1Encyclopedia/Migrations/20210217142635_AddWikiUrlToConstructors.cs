using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class AddWikiUrlToConstructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleSponsor",
                table: "Constructors");

            migrationBuilder.DropColumn(
                name: "Q3",
                table: "Qualifyings");

            migrationBuilder.DropColumn(
                name: "Q2",
                table: "Qualifyings");

            migrationBuilder.DropColumn(
                name: "Q1",
                table: "Qualifyings");

            migrationBuilder.AddColumn<long>(
                name: "Q3",
                table: "Qualifyings",
                type: "bigint",
                defaultValue: 0L,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Q2",
                table: "Qualifyings",
                type: "bigint",
                defaultValue: 0L,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Q1",
                table: "Qualifyings",
                type: "bigint",
                defaultValue: 0L,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WikiUrl",
                table: "Constructors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WikiUrl",
                table: "Constructors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Q3",
                table: "Qualifyings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Q2",
                table: "Qualifyings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Q1",
                table: "Qualifyings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleSponsor",
                table: "Constructors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
