using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.DataAccess.Postgress.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AuthorEntity = table.Column<string>(type: "text", nullable: true),
                    PreviousID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_courses_PreviousID",
                        column: x => x.PreviousID,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    CourseID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achievements_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "achievement_connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievement_connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achievement_connections_achievements_SourceId",
                        column: x => x.SourceId,
                        principalTable: "achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_achievement_connections_achievements_TargetId",
                        column: x => x.TargetId,
                        principalTable: "achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "achievement_criterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Expression = table.Column<string>(type: "text", nullable: false),
                    AchievementID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievement_criterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achievement_criterias_achievements_AchievementID",
                        column: x => x.AchievementID,
                        principalTable: "achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AchievementGotDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AchievementFoundDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsNotificationSeen = table.Column<bool>(type: "boolean", nullable: false),
                    IsFirstAnimationShown = table.Column<bool>(type: "boolean", nullable: false),
                    AchievementID = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_achievements_achievements_AchievementID",
                        column: x => x.AchievementID,
                        principalTable: "achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_achievements_students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievement_connections_SourceId_TargetId",
                table: "achievement_connections",
                columns: new[] { "SourceId", "TargetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_achievement_connections_TargetId",
                table: "achievement_connections",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_achievement_criterias_AchievementID",
                table: "achievement_criterias",
                column: "AchievementID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_achievements_CourseID",
                table: "achievements",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_courses_PreviousID",
                table: "courses",
                column: "PreviousID");

            migrationBuilder.CreateIndex(
                name: "IX_student_achievements_AchievementID",
                table: "student_achievements",
                column: "AchievementID");

            migrationBuilder.CreateIndex(
                name: "IX_student_achievements_StudentID_AchievementID",
                table: "student_achievements",
                columns: new[] { "StudentID", "AchievementID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievement_connections");

            migrationBuilder.DropTable(
                name: "achievement_criterias");

            migrationBuilder.DropTable(
                name: "student_achievements");

            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
