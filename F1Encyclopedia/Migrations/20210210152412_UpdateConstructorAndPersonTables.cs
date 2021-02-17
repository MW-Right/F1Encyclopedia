using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Encyclopedia.Migrations
{
    public partial class UpdateConstructorAndPersonTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colours_Constructors_ConstructorId",
                table: "Colours");

            migrationBuilder.DropForeignKey(
                name: "FK_Constructors_Countries_CountryId",
                table: "Constructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_NationalityId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DriverInformationId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_NationalityId",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverInformationId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Countries",
                nullable: true);

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
                name: "FK_Colours_Constructors_ConstructorId",
                table: "Colours",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Constructors_Countries_CountryId",
                table: "Constructors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colours_Constructors_ConstructorId",
                table: "Colours");

            migrationBuilder.DropForeignKey(
                name: "FK_Constructors_Countries_CountryId",
                table: "Constructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DriverInformationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DriverInformationId",
                table: "Persons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DriverInformationId",
                table: "Persons",
                column: "DriverInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NationalityId",
                table: "Persons",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colours_Constructors_ConstructorId",
                table: "Colours",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Constructors_Countries_CountryId",
                table: "Constructors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_NationalityId",
                table: "Persons",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
