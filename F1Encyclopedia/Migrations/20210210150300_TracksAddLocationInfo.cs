using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class TracksAddLocationInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Countries_CountryId",
                table: "Tracks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tracks",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Altitude",
                table: "Tracks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tracks",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Lattitude",
                table: "Tracks",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Tracks",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "WikiUrl",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Countries_CountryId",
                table: "Tracks",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Countries_CountryId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "WikiUrl",
                table: "Tracks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Countries_CountryId",
                table: "Tracks",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
