using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLessonRichtingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "RichtingId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "RichtingId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
