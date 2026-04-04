using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.DataAccess.Postgress.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentNumberAndAcademicDataJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicDataJson",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalStudentNumberRaw",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "students",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicDataJson",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ExternalStudentNumberRaw",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "students");
        }
    }
}
