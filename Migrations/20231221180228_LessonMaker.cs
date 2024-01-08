using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonMaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonMakerId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonMakerId",
                table: "Lessons",
                column: "LessonMakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_LessonMakerId",
                table: "Lessons",
                column: "LessonMakerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_LessonMakerId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonMakerId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonMakerId",
                table: "Lessons");
        }
    }
}
