using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonAndTraject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Lesson_LessonId",
                table: "Group");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Group_LessonId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Group");
        }
    }
}
