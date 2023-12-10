using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonGemaakt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Ended",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Started",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Traject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traject_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Traject_LessonId",
                table: "Traject",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traject");

            migrationBuilder.DropColumn(
                name: "Ended",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "Lesson");
        }
    }
}
