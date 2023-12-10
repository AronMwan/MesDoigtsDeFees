using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class LessonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Lessons");
        }
    }
}
