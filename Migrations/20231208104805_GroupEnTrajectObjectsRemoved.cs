using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class GroupEnTrajectObjectsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Lesson_LessonId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Traject_Lesson_LessonId",
                table: "Traject");

            migrationBuilder.DropIndex(
                name: "IX_Traject_LessonId",
                table: "Traject");

            migrationBuilder.DropIndex(
                name: "IX_Group_LessonId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Traject");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Traject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traject_LessonId",
                table: "Traject",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_LessonId",
                table: "Group",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Lesson_LessonId",
                table: "Group",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Traject_Lesson_LessonId",
                table: "Traject",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");
        }
    }
}
