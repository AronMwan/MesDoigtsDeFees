using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonRichting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonRichting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RichtingId = table.Column<int>(type: "int", nullable: false),
                    RichtingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonRichting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonRichting_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LessonRichting_Richtings_RichtingId",
                        column: x => x.RichtingId,
                        principalTable: "Richtings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonRichting_LessonId",
                table: "LessonRichting",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRichting_RichtingId",
                table: "LessonRichting",
                column: "RichtingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonRichting");
        }
    }
}
