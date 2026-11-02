using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolwebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherCategoryTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministrationTitle",
                table: "Teachers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HodTitle",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseMasterTitle",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrationTitle",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "HodTitle",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "HouseMasterTitle",
                table: "Teachers");
        }
    }
}
