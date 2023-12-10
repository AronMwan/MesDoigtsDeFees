using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LessonId",
                table: "Groups",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Lessons_LessonId",
                table: "Groups",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Lessons_LessonId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_LessonId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Groups");
        }
    }
}
