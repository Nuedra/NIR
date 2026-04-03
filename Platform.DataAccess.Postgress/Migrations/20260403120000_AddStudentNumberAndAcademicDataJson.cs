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

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                """
                UPDATE "students" AS s
                SET "StudentNumber" = sub.rn
                FROM (
                    SELECT "Id", (ROW_NUMBER() OVER (ORDER BY "Id"))::integer AS rn
                    FROM "students"
                ) AS sub
                WHERE s."Id" = sub."Id";
                """);

            migrationBuilder.Sql(
                """ALTER TABLE "students" ALTER COLUMN "StudentNumber" DROP DEFAULT;""");

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentNumber",
                table: "students",
                column: "StudentNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_students_StudentNumber",
                table: "students");

            migrationBuilder.DropColumn(
                name: "AcademicDataJson",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "students");
        }
    }
}
