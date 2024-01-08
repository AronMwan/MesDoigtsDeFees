using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class RelatieUserEnLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MesDoigtsDeFeesUserId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_MesDoigtsDeFeesUserId",
                table: "Lessons",
                column: "MesDoigtsDeFeesUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_MesDoigtsDeFeesUserId",
                table: "Lessons",
                column: "MesDoigtsDeFeesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_MesDoigtsDeFeesUserId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_MesDoigtsDeFeesUserId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "MesDoigtsDeFeesUserId",
                table: "Lessons");
        }
    }
}
