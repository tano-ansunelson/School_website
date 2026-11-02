using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolwebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdministration",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHod",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHouseMaster",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdministration",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsHod",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsHouseMaster",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "Teachers");
        }
    }
}
