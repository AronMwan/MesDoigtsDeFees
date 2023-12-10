using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonRichtingsNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonRichting_Lessons_LessonId",
                table: "LessonRichting");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonRichting_Richtings_RichtingId",
                table: "LessonRichting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonRichting",
                table: "LessonRichting");

            migrationBuilder.RenameTable(
                name: "LessonRichting",
                newName: "LessonRichtings");

            migrationBuilder.RenameIndex(
                name: "IX_LessonRichting_RichtingId",
                table: "LessonRichtings",
                newName: "IX_LessonRichtings_RichtingId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonRichting_LessonId",
                table: "LessonRichtings",
                newName: "IX_LessonRichtings_LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonRichtings",
                table: "LessonRichtings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonRichtings_Lessons_LessonId",
                table: "LessonRichtings",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonRichtings_Richtings_RichtingId",
                table: "LessonRichtings",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonRichtings_Lessons_LessonId",
                table: "LessonRichtings");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonRichtings_Richtings_RichtingId",
                table: "LessonRichtings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonRichtings",
                table: "LessonRichtings");

            migrationBuilder.RenameTable(
                name: "LessonRichtings",
                newName: "LessonRichting");

            migrationBuilder.RenameIndex(
                name: "IX_LessonRichtings_RichtingId",
                table: "LessonRichting",
                newName: "IX_LessonRichting_RichtingId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonRichtings_LessonId",
                table: "LessonRichting",
                newName: "IX_LessonRichting_LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonRichting",
                table: "LessonRichting",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonRichting_Lessons_LessonId",
                table: "LessonRichting",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonRichting_Richtings_RichtingId",
                table: "LessonRichting",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
